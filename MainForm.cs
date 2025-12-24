using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace NGVault
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private static readonly byte[] Magic = Encoding.ASCII.GetBytes("NGVault");
        private const byte Format1 = 0x01;

        private const byte AlgId_AesGcm = 0x01;

        private const int SaltSize = 16;
        private const int NonceSize = 12;
        private const int TagSize = 16;
        private const int KeySizeBytes = 32;

        private const int DefaultPbkdf2Iterations = 300_000;

        private const int MinPasswordLength = 10;

#pragma warning disable IDE0044
        private static bool EnableBestEffortWipe = false;
#pragma warning restore IDE0044
        private const int BestEffortWipePasses = 1;

        private readonly BindingList<FileItem> _items = new BindingList<FileItem>();
        private CancellationTokenSource _cts;

        private readonly Color RowProcessingColor = Color.FromArgb(255, 249, 230);
        private readonly Color RowSuccessColor = Color.FromArgb(230, 245, 233);
        private readonly Color RowErrorColor = Color.FromArgb(250, 232, 232);
        private readonly Color RowDefaultColor = Color.White;

        public MainForm()
        {
            InitializeComponent();
            InitUi();
        }

        private void InitUi()
        {
            PictureBoxDragDropFiles.AllowDrop = true;

            DatagridViewFileList.AutoGenerateColumns = false;
            DatagridViewFileList.DataSource = _items;
            EnsureGridColumns();

            RadioButtonAutomaticSense.Checked = false;
            RadioButtonWriteOnFile.Checked = false;
            RadioButtonWriteNewFile.Checked = false;
            RadioButtonCrypt.Checked = false;
            RadioButtonDecrypt.Checked = false;

            ProgressBarGeneral.Minimum = 0;
            ProgressBarGeneral.Value = 0;

            LabelGeneralStatus.Text = "Hazır";
            LabelGeneralStatus.ForeColor = Color.Green;
            LabelDetailStatus.Visible = false;
            ButtonStopProcess.Enabled = false;
        }

        private void EnsureGridColumns()
        {
            if (DatagridViewFileList.Columns.Count > 0) return;

            DatagridViewFileList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(FileItem.FileName),
                HeaderText = "Dosya",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            DatagridViewFileList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(FileItem.SizeText),
                HeaderText = "Boyut",
                Width = 90
            });
            DatagridViewFileList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(FileItem.StateText),
                HeaderText = "Durum",
                Width = 90
            });
            DatagridViewFileList.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(FileItem.Result),
                HeaderText = "Sonuç",
                Width = 180
            });
        }

        private void AddFiles(IEnumerable<string> paths)
        {
            foreach (var p in paths)
            {
                if (string.IsNullOrWhiteSpace(p) || !File.Exists(p)) continue;
                if (_items.Any(x => string.Equals(x.Path, p, StringComparison.OrdinalIgnoreCase)))
                    continue;

                var fi = new FileInfo(p);
                var state = DetectFileState(p);
                _items.Add(new FileItem
                {
                    Path = p,
                    SizeBytes = fi.Length,
                    State = state,
                    Result = "Hazır"
                });
            }
        }

        private bool ValidateUserSelections()
        {
            bool isOperationSelected =
                RadioButtonAutomaticSense.Checked ||
                RadioButtonCrypt.Checked ||
                RadioButtonDecrypt.Checked;

            if (!isOperationSelected)
            {
                MessageBox.Show(
                    "Lütfen bir işlem türü seçin.\n\n" +
                    "• Otomatik Algıla\n" +
                    "• Şifrele\n" +
                    "• Şifre Çöz",
                    "İşlem Türü Seçilmedi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            // Yazma yöntemi kontrolü
            bool isWriteModeSelected =
                RadioButtonWriteOnFile.Checked ||
                RadioButtonWriteNewFile.Checked;

            if (!isWriteModeSelected)
            {
                MessageBox.Show(
                    "Lütfen dosyanın nasıl kaydedileceğini seçin.\n\n" +
                    "• Aynı dosyanın üzerine yaz\n" +
                    "• Yeni dosya oluştur",
                    "Kaydetme Yöntemi Seçilmedi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            return true;
        }

        private async Task StartAsync()
        {
            if (_items.Count == 0)
            {
                MessageBox.Show("Lütfen en az bir dosya ekleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateUserSelections())
                return;

            string pwd = (TextBoxPassword.Text ?? "").Trim();
            string pwd2 = (TextBoxPasswordAgain.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(pwd) || string.IsNullOrWhiteSpace(pwd2))
            {
                MessageBox.Show("Şifreler boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (pwd.Length < MinPasswordLength)
            {
                MessageBox.Show($"Şifre en az {MinPasswordLength} karakter olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!string.Equals(pwd, pwd2, StringComparison.Ordinal))
            {
                MessageBox.Show("Şifreler eşleşmiyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ButtonExit.Enabled = false;
            ButtonStartProcess.Enabled = false;
            ButtonStopProcess.Enabled = true;

            ProgressBarGeneral.Value = 0;
            ProgressBarGeneral.Maximum = _items.Count;
            LabelGeneralStatus.Text = "İşlem başladı...";
            LabelGeneralStatus.ForeColor = Color.Orange;

            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            byte[] passwordBytes = Encoding.UTF8.GetBytes(pwd);

            try
            {
                for (int i = 0; i < _items.Count; i++)
                {
                    token.ThrowIfCancellationRequested();

                    var item = _items[i];
                    item.Result = "İşleniyor...";
                    DatagridViewFileList.Refresh();

                    SetRowColor(item, RowProcessingColor);

                    try
                    {
                        var mode = GetUserMode(item);

                        await Task.Run(() =>
                        {
                            ProcessOneFile(item.Path, passwordBytes, mode, token);
                        }, token);

                        item.State = DetectFileState(item.Path);
                        item.Result = "Başarılı";

                        SetRowColor(item, RowSuccessColor);
                    }
                    catch (OperationCanceledException)
                    {
                        item.Result = "İptal edildi";
                        SetRowColor(item, RowDefaultColor);
                        throw;
                    }
                    catch (NGVaultWrongPasswordException)
                    {
                        item.Result = "Hata: Şifre yanlış veya dosya bozulmuş";
                        SetRowColor(item, RowErrorColor);
                    }
                    catch (NGVaultCorruptedDataException)
                    {
                        item.Result = "Hata: Dosya bozuk/kurcalanmış";
                        SetRowColor(item, RowErrorColor);
                    }
                    catch (NGVaultNotEncryptedException)
                    {
                        item.Result = "Hata: Şifreli değil";
                        SetRowColor(item, RowErrorColor);
                    }
                    catch (Exception ex)
                    {
                        item.Result = "Hata: " + ex.Message;
                        SetRowColor(item, RowErrorColor);
                    }
                    finally
                    {
                        LabelDetailStatus.Visible = true;
                        ProgressBarGeneral.Value = Math.Min(ProgressBarGeneral.Maximum, i + 1);
                        LabelDetailStatus.Text = $"{i + 1}/{_items.Count} tamamlandı";
                        DatagridViewFileList.Refresh();
                    }
                }

                LabelGeneralStatus.Text = "Tamamlandı";
                LabelGeneralStatus.ForeColor = Color.Green;
            }
            catch (OperationCanceledException)
            {
                LabelGeneralStatus.Text = "İşlem iptal edildi";
                LabelGeneralStatus.ForeColor = Color.Red;
            }
            finally
            {
                ButtonExit.Enabled = true;
                SecureZero(passwordBytes);

                ButtonStartProcess.Enabled = true;
                ButtonStopProcess.Enabled = false;

                _cts.Dispose();
                _cts = null;
            }
        }

        private void SetRowColor(FileItem item, Color color)
        {
            if (DatagridViewFileList.InvokeRequired)
            {
                DatagridViewFileList.Invoke(new Action(() => SetRowColor(item, color)));
                return;
            }

            foreach (DataGridViewRow row in DatagridViewFileList.Rows)
            {
                if (row.DataBoundItem == item)
                {
                    row.DefaultCellStyle.BackColor = color;
                    break;
                }
            }
        }

        private UserMode GetUserMode(FileItem item)
        {
            if (RadioButtonAutomaticSense.Checked)
                return item.State == FileState.Encrypted ? UserMode.Decrypt : UserMode.Encrypt;

            if (RadioButtonCrypt.Checked) return UserMode.Encrypt;
            return UserMode.Decrypt;
        }

        private string EnsureUniquePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Path boş olamaz.", nameof(path));

            if (!File.Exists(path))
                return path;

            string dir = Path.GetDirectoryName(path);
            string name = Path.GetFileNameWithoutExtension(path);
            string ext = Path.GetExtension(path);

            for (int i = 1; i < 10000; i++)
            {
                string candidate = Path.Combine(dir, $"{name}({i}){ext}");
                if (!File.Exists(candidate))
                    return candidate;
            }

            throw new IOException("Benzersiz dosya adı üretilemedi (çok fazla çakışma).");
        }

        private void ProcessOneFile(string path, byte[] passwordBytes, UserMode mode, CancellationToken token)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Dosya bulunamadı.", path);

            bool overwrite = RadioButtonWriteOnFile.Checked || !RadioButtonWriteNewFile.Checked;
            string outputPath = overwrite ? path : EnsureUniquePath(MakeDerivedOutputPath(path, mode));

            string dir = Path.GetDirectoryName(outputPath);
            string tempPath = Path.Combine(dir, Path.GetRandomFileName() + ".tmp");

            try
            {
                if (mode == UserMode.Encrypt)
                {
                    EncryptFile_Format1_Gcm(path, tempPath, passwordBytes, DefaultPbkdf2Iterations, token);

                    if (EnableBestEffortWipe)
                    {
                        try { BestEffortWipeFile(path, BestEffortWipePasses); } catch { }
                    }

                    ReplaceAtomically(tempPath, outputPath);
                }
                else
                {
                    if (DetectFileState(path) != FileState.Encrypted)
                        throw new NGVaultNotEncryptedException();

                    DecryptFile_Format1_Gcm(path, tempPath, passwordBytes, token);
                    ReplaceAtomically(tempPath, outputPath);
                }
            }
            finally
            {
                try { if (File.Exists(tempPath)) File.Delete(tempPath); } catch { }
            }
        }

        private string MakeDerivedOutputPath(string inputPath, UserMode mode)
        {
            string dir = Path.GetDirectoryName(inputPath);
            string name = Path.GetFileNameWithoutExtension(inputPath);
            string ext = Path.GetExtension(inputPath);

            if (mode == UserMode.Encrypt)
            {
                return Path.Combine(dir, $"{name}_encrypted{ext}");
            }
            else
            {
                return Path.Combine(dir, $"{name}_decrypted{ext}");
            }
        }

        private FileState DetectFileState(string path)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    int need = Magic.Length + 1;
                    byte[] hdr = new byte[need];
                    int r = fs.Read(hdr, 0, hdr.Length);
                    if (r != need) return FileState.Plain;

                    if (!hdr.Take(Magic.Length).SequenceEqual(Magic))
                        return FileState.Plain;

                    byte fmt = hdr[Magic.Length];
                    return fmt == Format1 ? FileState.Encrypted : FileState.Plain;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DetectFileState error: " + ex);
                return FileState.Unknown;
            }
        }

        private static byte[] DeriveKeyPbkdf2(byte[] passwordBytes, byte[] salt, int iterations, int size)
        {
            using (var kdf = new Rfc2898DeriveBytes(passwordBytes, salt, iterations, HashAlgorithmName.SHA256))
            {
                return kdf.GetBytes(size);
            }
        }

        private void EncryptFile_Format1_Gcm(string inputPath, string tempPath, byte[] passwordBytes, int iterations, CancellationToken token)
        {
            byte[] salt = new byte[SaltSize];
            byte[] nonce = new byte[NonceSize];
            var sr = new SecureRandom();
            sr.NextBytes(salt);
            sr.NextBytes(nonce);

            byte[] key = DeriveKeyPbkdf2(passwordBytes, salt, iterations, KeySizeBytes);

            try
            {
                using (var inFs = new FileStream(inputPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (var outFs = new FileStream(tempPath, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None))
                {
                    outFs.Write(Magic, 0, Magic.Length);
                    outFs.WriteByte(Format1);

                    outFs.WriteByte(AlgId_AesGcm);

                    byte[] iterBytes = BitConverter.GetBytes(iterations);
                    outFs.Write(iterBytes, 0, iterBytes.Length);

                    outFs.Write(salt, 0, salt.Length);
                    outFs.Write(nonce, 0, nonce.Length);

                    long tagPos = outFs.Position;
                    outFs.Write(new byte[TagSize], 0, TagSize);

                    byte[] aad = BuildAad_Format1(iterations, salt, nonce);

                    var cipher = new GcmBlockCipher(new Org.BouncyCastle.Crypto.Engines.AesEngine());
                    var parameters = new AeadParameters(new KeyParameter(key), TagSize * 8, nonce, aad);
                    cipher.Init(true, parameters);

                    byte[] inBuf = new byte[1024 * 1024];

                    int read;
                    while ((read = inFs.Read(inBuf, 0, inBuf.Length)) > 0)
                    {
                        token.ThrowIfCancellationRequested();

                        int outSize = cipher.GetUpdateOutputSize(read);
                        if (outSize < 0) outSize = 0;

                        byte[] outBuf = (outSize == 0) ? new byte[Math.Max(1, read)] : new byte[outSize];

                        int len = cipher.ProcessBytes(inBuf, 0, read, outBuf, 0);
                        if (len > 0)
                            outFs.Write(outBuf, 0, len);
                    }

                    byte[] finalBuf = new byte[cipher.GetOutputSize(0)];
                    int finalLen = cipher.DoFinal(finalBuf, 0);
                    if (finalLen > 0)
                        outFs.Write(finalBuf, 0, finalLen);

                    outFs.Flush(true);

                    long fileLen = outFs.Length;
                    if (fileLen < tagPos + TagSize + 1)
                        throw new NGVaultCorruptedDataException("Şifreleme çıktısı beklenenden kısa.");

                    outFs.Position = fileLen - TagSize;

                    byte[] tag = new byte[TagSize];
                    int tr = outFs.Read(tag, 0, TagSize);
                    if (tr != TagSize)
                        throw new NGVaultCorruptedDataException("Tag okunamadı.");

                    outFs.Position = tagPos;
                    outFs.Write(tag, 0, tag.Length);

                    outFs.SetLength(fileLen - TagSize);
                }
            }
            finally
            {
                SecureZero(key);
            }
        }

        private static byte[] BuildAad_Format1(int iterations, byte[] salt, byte[] nonce)
        {
            byte[] iterBytes = BitConverter.GetBytes(iterations);
            using (var ms = new MemoryStream())
            {
                ms.Write(Magic, 0, Magic.Length);
                ms.WriteByte(Format1);
                ms.WriteByte(AlgId_AesGcm);
                ms.Write(iterBytes, 0, iterBytes.Length);
                ms.Write(salt, 0, salt.Length);
                ms.Write(nonce, 0, nonce.Length);
                return ms.ToArray();
            }
        }

        private void DecryptFile_Format1_Gcm(string inputPath, string tempPath, byte[] passwordBytes, CancellationToken token)
        {
            using (var inFs = new FileStream(inputPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] magic = ReadExactly(inFs, Magic.Length);
                if (!magic.SequenceEqual(Magic))
                    throw new NGVaultCorruptedDataException("Magic uyuşmuyor.");

                int fmt = inFs.ReadByte();
                if (fmt != Format1)
                    throw new NGVaultCorruptedDataException("Format desteklenmiyor.");

                int alg = inFs.ReadByte();
                if (alg != AlgId_AesGcm)
                    throw new NGVaultCorruptedDataException("Algoritma desteklenmiyor.");

                int iterations = BitConverter.ToInt32(ReadExactly(inFs, 4), 0);
                if (iterations <= 0)
                    throw new NGVaultCorruptedDataException("Iterations geçersiz.");

                byte[] salt = ReadExactly(inFs, SaltSize);
                byte[] nonce = ReadExactly(inFs, NonceSize);
                byte[] tag = ReadExactly(inFs, TagSize);

                long cipherStart = inFs.Position;
                long remaining = inFs.Length - cipherStart;
                if (remaining <= 0)
                    throw new NGVaultCorruptedDataException("Ciphertext yok.");

                byte[] key = DeriveKeyPbkdf2(passwordBytes, salt, iterations, KeySizeBytes);

                try
                {
                    byte[] aad = BuildAad_Format1(iterations, salt, nonce);

                    var cipher = new GcmBlockCipher(new Org.BouncyCastle.Crypto.Engines.AesEngine());
                    var parameters = new AeadParameters(new KeyParameter(key), TagSize * 8, nonce, aad);
                    cipher.Init(false, parameters);

                    using (var outFs = new FileStream(tempPath, FileMode.CreateNew, FileAccess.Write, FileShare.None))
                    {
                        byte[] inBuf = new byte[1024 * 1024]; // 1MB

                        int read;
                        while ((read = inFs.Read(inBuf, 0, inBuf.Length)) > 0)
                        {
                            token.ThrowIfCancellationRequested();

                            int outSize = cipher.GetUpdateOutputSize(read);
                            if (outSize < 0) outSize = 0;

                            byte[] outBuf = (outSize == 0) ? new byte[Math.Max(1, read)] : new byte[outSize];

                            int len = cipher.ProcessBytes(inBuf, 0, read, outBuf, 0);
                            if (len > 0)
                                outFs.Write(outBuf, 0, len);
                        }

                        int outSizeTag = cipher.GetUpdateOutputSize(tag.Length);
                        if (outSizeTag < 0) outSizeTag = 0;

                        byte[] outBufTag = (outSizeTag == 0) ? new byte[Math.Max(1, tag.Length)] : new byte[outSizeTag];

                        int len2 = cipher.ProcessBytes(tag, 0, tag.Length, outBufTag, 0);
                        if (len2 > 0)
                            outFs.Write(outBufTag, 0, len2);

                        try
                        {
                            byte[] finalBuf = new byte[cipher.GetOutputSize(0)];
                            int finalLen = cipher.DoFinal(finalBuf, 0);
                            if (finalLen > 0)
                                outFs.Write(finalBuf, 0, finalLen);
                        }
                        catch (InvalidCipherTextException)
                        {
                            throw new NGVaultWrongPasswordException();
                        }
                    }
                }
                finally
                {
                    SecureZero(key);
                }
            }
        }

        private static void SecureZero(byte[] data)
        {
            if (data == null) return;
            Array.Clear(data, 0, data.Length);
        }

        private static byte[] ReadExactly(FileStream fs, int len)
        {
            byte[] buf = new byte[len];
            int off = 0;
            while (off < len)
            {
                int r = fs.Read(buf, off, len - off);
                if (r <= 0) throw new EndOfStreamException("Beklenmeyen dosya sonu.");
                off += r;
            }
            return buf;
        }

        private void ReplaceAtomically(string tempPath, string finalPath)
        {
            if (File.Exists(finalPath))
                File.Replace(tempPath, finalPath, null, ignoreMetadataErrors: true);
            else
                File.Move(tempPath, finalPath);
        }

        private void BestEffortWipeFile(string path, int passes = 1)
        {
            var fi = new FileInfo(path);
            long length = fi.Length;
            if (length <= 0) return;

            byte[] buffer = new byte[1024 * 1024];
            using (var rng = RandomNumberGenerator.Create())
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.None))
            {
                for (int p = 0; p < passes; p++)
                {
                    fs.Position = 0;
                    long remaining = length;
                    while (remaining > 0)
                    {
                        int toWrite = (int)Math.Min(buffer.Length, remaining);
                        rng.GetBytes(buffer, 0, toWrite);
                        fs.Write(buffer, 0, toWrite);
                        remaining -= toWrite;
                    }
                    fs.Flush(true);
                }
            }
        }

        private void ButtonTips_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "NGVault – Dosya Şifreleme Aracı\n\n" +
                "Bu program, seçtiğiniz dosyaları güçlü AES-256 GCM şifreleme yöntemi ile korur.\n\n" +
                "KULLANIM BİLGİLERİ:\n" +
                "• Dosyalarınızı sürükleyip bırakabilir veya Dosya / Klasör Seç butonlarını kullanabilirsiniz.\n" +
                "• Bir işlem türü seçmelisiniz:\n" +
                "  - Otomatik Algıla (şifreli dosyayı çözer, şifresiz dosyayı şifreler)\n" +
                "  - Şifrele\n" +
                "  - Şifre Çöz\n" +
                "• Dosyanın nasıl kaydedileceğini seçmelisiniz:\n" +
                "  - Aynı dosyanın üzerine yaz\n" +
                "  - Yeni dosya oluştur\n\n" +
                "ÖNEMLİ UYARILAR:\n" +
                "• Şifreli dosyaların uzantısı korunur. Dosyanın şifreli olup olmadığı uzantıya göre değil, program imzasına göre anlaşılır.\n" +
                "• Şifrenizi UNUTURSANIZ dosyalarınız GERİ GETİRİLEMEZ.\n" +
                "• Yanlış şifre girilmesi veya dosyanın değiştirilmesi durumunda çözme işlemi başarısız olur.\n\n" +
                "Bu program dosya güvenliğini artırmak için tasarlanmıştır. " +
                "Şifrelerinizi güvenli bir yerde saklamak tamamen kullanıcının sorumluluğundadır.",
                "NGVault – Kullanım Bilgilendirmesi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBoxBlueArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void PictureBoxDragDropFiles_DragEnter_1(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop)
                ? DragDropEffects.Copy
                : DragDropEffects.None;
        }

        private void PictureBoxDragDropFiles_DragDrop(object sender, DragEventArgs e)
        {
            var dropped = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (dropped == null || dropped.Length == 0) return;

            var expanded = new List<string>();
            foreach (var f in dropped)
            {
                if (Directory.Exists(f))
                    expanded.AddRange(Directory.GetFiles(f, "*", SearchOption.TopDirectoryOnly));
                else if (File.Exists(f))
                    expanded.Add(f);
            }

            AddFiles(expanded);
        }

        private void ButtonFileSelect_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                ofd.Title = "Dosya seç";
                if (ofd.ShowDialog(this) == DialogResult.OK)
                    AddFiles(ofd.FileNames);
            }
        }

        private void ButtonFolderSelect_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Klasör seç";
                if (fbd.ShowDialog(this) == DialogResult.OK)
                {
                    var files = Directory.GetFiles(fbd.SelectedPath, "*", SearchOption.TopDirectoryOnly);
                    AddFiles(files);
                }
            }
        }

        private void ButtonSelectedRemove_Click(object sender, EventArgs e)
        {
            var selected = DatagridViewFileList.SelectedRows.Cast<DataGridViewRow>()
                .Select(r => r.DataBoundItem as FileItem)
                .Where(x => x != null)
                .ToList();

            foreach (var it in selected)
                _items.Remove(it);
        }

        private void ButtonAllRemove_Click(object sender, EventArgs e)
        {
            _items.Clear();
        }

        private void ButtonStopProcess_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
        }

        private void CheckBoxPasswordUnseen_CheckedChanged(object sender, EventArgs e)
        {
            bool show = CheckBoxPasswordUnseen.Checked;
            TextBoxPassword.UseSystemPasswordChar = !show;
            TextBoxPasswordAgain.UseSystemPasswordChar = !show;
        }

        private async void ButtonStartProcess_Click(object sender, EventArgs e)
        {
            await StartAsync();
        }
    }
}