namespace NGVault
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxPasswordAgain = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CheckBoxPasswordUnseen = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PictureBoxBlueArea = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.PictureBoxDragDropFiles = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RadioButtonDecrypt = new System.Windows.Forms.RadioButton();
            this.RadioButtonCrypt = new System.Windows.Forms.RadioButton();
            this.RadioButtonAutomaticSense = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DatagridViewFileList = new System.Windows.Forms.DataGridView();
            this.ButtonFileSelect = new System.Windows.Forms.Button();
            this.ButtonFolderSelect = new System.Windows.Forms.Button();
            this.ButtonSelectedRemove = new System.Windows.Forms.Button();
            this.ButtonAllRemove = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.LabelGeneralStatus = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.ButtonStopProcess = new System.Windows.Forms.Button();
            this.ButtonStartProcess = new System.Windows.Forms.Button();
            this.ProgressBarGeneral = new System.Windows.Forms.ProgressBar();
            this.LabelDetailStatus = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RadioButtonWriteNewFile = new System.Windows.Forms.RadioButton();
            this.RadioButtonWriteOnFile = new System.Windows.Forms.RadioButton();
            this.ButtonTips = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxBlueArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxDragDropFiles)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DatagridViewFileList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Location = new System.Drawing.Point(108, 26);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.Size = new System.Drawing.Size(154, 27);
            this.TextBoxPassword.TabIndex = 0;
            this.TextBoxPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Şifre:";
            // 
            // TextBoxPasswordAgain
            // 
            this.TextBoxPasswordAgain.Location = new System.Drawing.Point(107, 67);
            this.TextBoxPasswordAgain.Name = "TextBoxPasswordAgain";
            this.TextBoxPasswordAgain.Size = new System.Drawing.Size(154, 27);
            this.TextBoxPasswordAgain.TabIndex = 1;
            this.TextBoxPasswordAgain.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Şifre Onay:";
            // 
            // CheckBoxPasswordUnseen
            // 
            this.CheckBoxPasswordUnseen.AutoSize = true;
            this.CheckBoxPasswordUnseen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckBoxPasswordUnseen.Location = new System.Drawing.Point(144, 106);
            this.CheckBoxPasswordUnseen.Name = "CheckBoxPasswordUnseen";
            this.CheckBoxPasswordUnseen.Size = new System.Drawing.Size(114, 23);
            this.CheckBoxPasswordUnseen.TabIndex = 13;
            this.CheckBoxPasswordUnseen.Text = "Şifreyi Göster";
            this.CheckBoxPasswordUnseen.UseVisualStyleBackColor = true;
            this.CheckBoxPasswordUnseen.CheckedChanged += new System.EventHandler(this.CheckBoxPasswordUnseen_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(38, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "NGVault - AES-256 GCM File Encryption";
            // 
            // PictureBoxBlueArea
            // 
            this.PictureBoxBlueArea.BackColor = System.Drawing.SystemColors.HotTrack;
            this.PictureBoxBlueArea.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxBlueArea.Name = "PictureBoxBlueArea";
            this.PictureBoxBlueArea.Size = new System.Drawing.Size(900, 40);
            this.PictureBoxBlueArea.TabIndex = 17;
            this.PictureBoxBlueArea.TabStop = false;
            this.PictureBoxBlueArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxBlueArea_MouseDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(5, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // PictureBoxDragDropFiles
            // 
            this.PictureBoxDragDropFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBoxDragDropFiles.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureBoxDragDropFiles.Image = ((System.Drawing.Image)(resources.GetObject("PictureBoxDragDropFiles.Image")));
            this.PictureBoxDragDropFiles.Location = new System.Drawing.Point(12, 46);
            this.PictureBoxDragDropFiles.Name = "PictureBoxDragDropFiles";
            this.PictureBoxDragDropFiles.Size = new System.Drawing.Size(590, 185);
            this.PictureBoxDragDropFiles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxDragDropFiles.TabIndex = 19;
            this.PictureBoxDragDropFiles.TabStop = false;
            this.PictureBoxDragDropFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.PictureBoxDragDropFiles_DragDrop);
            this.PictureBoxDragDropFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.PictureBoxDragDropFiles_DragEnter_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RadioButtonDecrypt);
            this.groupBox1.Controls.Add(this.RadioButtonCrypt);
            this.groupBox1.Controls.Add(this.RadioButtonAutomaticSense);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.groupBox1.Location = new System.Drawing.Point(620, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 104);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Şifeleme İşlemi";
            // 
            // RadioButtonDecrypt
            // 
            this.RadioButtonDecrypt.AutoSize = true;
            this.RadioButtonDecrypt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RadioButtonDecrypt.Location = new System.Drawing.Point(6, 65);
            this.RadioButtonDecrypt.Name = "RadioButtonDecrypt";
            this.RadioButtonDecrypt.Size = new System.Drawing.Size(83, 23);
            this.RadioButtonDecrypt.TabIndex = 2;
            this.RadioButtonDecrypt.Text = "Şifre Çöz";
            this.RadioButtonDecrypt.UseVisualStyleBackColor = true;
            // 
            // RadioButtonCrypt
            // 
            this.RadioButtonCrypt.AutoSize = true;
            this.RadioButtonCrypt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RadioButtonCrypt.Location = new System.Drawing.Point(6, 42);
            this.RadioButtonCrypt.Name = "RadioButtonCrypt";
            this.RadioButtonCrypt.Size = new System.Drawing.Size(68, 23);
            this.RadioButtonCrypt.TabIndex = 1;
            this.RadioButtonCrypt.Text = "Şifrele";
            this.RadioButtonCrypt.UseVisualStyleBackColor = true;
            // 
            // RadioButtonAutomaticSense
            // 
            this.RadioButtonAutomaticSense.AutoSize = true;
            this.RadioButtonAutomaticSense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RadioButtonAutomaticSense.Location = new System.Drawing.Point(6, 19);
            this.RadioButtonAutomaticSense.Name = "RadioButtonAutomaticSense";
            this.RadioButtonAutomaticSense.Size = new System.Drawing.Size(192, 23);
            this.RadioButtonAutomaticSense.TabIndex = 0;
            this.RadioButtonAutomaticSense.Text = "Otomatik Algıla (Önerilen)";
            this.RadioButtonAutomaticSense.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.TextBoxPassword);
            this.groupBox3.Controls.Add(this.TextBoxPasswordAgain);
            this.groupBox3.Controls.Add(this.CheckBoxPasswordUnseen);
            this.groupBox3.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.groupBox3.Location = new System.Drawing.Point(620, 260);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(268, 136);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Şifre";
            // 
            // DatagridViewFileList
            // 
            this.DatagridViewFileList.AllowUserToAddRows = false;
            this.DatagridViewFileList.AllowUserToDeleteRows = false;
            this.DatagridViewFileList.BackgroundColor = System.Drawing.Color.White;
            this.DatagridViewFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatagridViewFileList.Location = new System.Drawing.Point(12, 275);
            this.DatagridViewFileList.Name = "DatagridViewFileList";
            this.DatagridViewFileList.ReadOnly = true;
            this.DatagridViewFileList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DatagridViewFileList.Size = new System.Drawing.Size(590, 196);
            this.DatagridViewFileList.TabIndex = 27;
            // 
            // ButtonFileSelect
            // 
            this.ButtonFileSelect.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonFileSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonFileSelect.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonFileSelect.ForeColor = System.Drawing.Color.White;
            this.ButtonFileSelect.Location = new System.Drawing.Point(12, 237);
            this.ButtonFileSelect.Name = "ButtonFileSelect";
            this.ButtonFileSelect.Size = new System.Drawing.Size(107, 32);
            this.ButtonFileSelect.TabIndex = 28;
            this.ButtonFileSelect.Text = "Dosya Seç...";
            this.ButtonFileSelect.UseVisualStyleBackColor = false;
            this.ButtonFileSelect.Click += new System.EventHandler(this.ButtonFileSelect_Click);
            // 
            // ButtonFolderSelect
            // 
            this.ButtonFolderSelect.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ButtonFolderSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonFolderSelect.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonFolderSelect.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonFolderSelect.Location = new System.Drawing.Point(124, 237);
            this.ButtonFolderSelect.Name = "ButtonFolderSelect";
            this.ButtonFolderSelect.Size = new System.Drawing.Size(107, 32);
            this.ButtonFolderSelect.TabIndex = 29;
            this.ButtonFolderSelect.Text = "Klasör Seç...";
            this.ButtonFolderSelect.UseVisualStyleBackColor = false;
            this.ButtonFolderSelect.Click += new System.EventHandler(this.ButtonFolderSelect_Click);
            // 
            // ButtonSelectedRemove
            // 
            this.ButtonSelectedRemove.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ButtonSelectedRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonSelectedRemove.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonSelectedRemove.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ButtonSelectedRemove.Location = new System.Drawing.Point(12, 477);
            this.ButtonSelectedRemove.Name = "ButtonSelectedRemove";
            this.ButtonSelectedRemove.Size = new System.Drawing.Size(127, 32);
            this.ButtonSelectedRemove.TabIndex = 31;
            this.ButtonSelectedRemove.Text = "Seçileni Kaldır";
            this.ButtonSelectedRemove.UseVisualStyleBackColor = false;
            this.ButtonSelectedRemove.Click += new System.EventHandler(this.ButtonSelectedRemove_Click);
            // 
            // ButtonAllRemove
            // 
            this.ButtonAllRemove.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ButtonAllRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAllRemove.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonAllRemove.ForeColor = System.Drawing.Color.IndianRed;
            this.ButtonAllRemove.Location = new System.Drawing.Point(145, 477);
            this.ButtonAllRemove.Name = "ButtonAllRemove";
            this.ButtonAllRemove.Size = new System.Drawing.Size(127, 32);
            this.ButtonAllRemove.TabIndex = 32;
            this.ButtonAllRemove.Text = "Tümünü Kaldır";
            this.ButtonAllRemove.UseVisualStyleBackColor = false;
            this.ButtonAllRemove.Click += new System.EventHandler(this.ButtonAllRemove_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pictureBox6.Location = new System.Drawing.Point(0, 560);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(900, 1);
            this.pictureBox6.TabIndex = 33;
            this.pictureBox6.TabStop = false;
            // 
            // LabelGeneralStatus
            // 
            this.LabelGeneralStatus.AutoSize = true;
            this.LabelGeneralStatus.BackColor = System.Drawing.Color.White;
            this.LabelGeneralStatus.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LabelGeneralStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.LabelGeneralStatus.Location = new System.Drawing.Point(12, 572);
            this.LabelGeneralStatus.Name = "LabelGeneralStatus";
            this.LabelGeneralStatus.Size = new System.Drawing.Size(52, 19);
            this.LabelGeneralStatus.TabIndex = 34;
            this.LabelGeneralStatus.Text = "Durum";
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pictureBox7.Location = new System.Drawing.Point(0, 515);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(900, 1);
            this.pictureBox7.TabIndex = 35;
            this.pictureBox7.TabStop = false;
            // 
            // ButtonStopProcess
            // 
            this.ButtonStopProcess.BackColor = System.Drawing.Color.IndianRed;
            this.ButtonStopProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonStopProcess.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonStopProcess.ForeColor = System.Drawing.Color.White;
            this.ButtonStopProcess.Location = new System.Drawing.Point(781, 522);
            this.ButtonStopProcess.Name = "ButtonStopProcess";
            this.ButtonStopProcess.Size = new System.Drawing.Size(107, 32);
            this.ButtonStopProcess.TabIndex = 37;
            this.ButtonStopProcess.Text = "İptal";
            this.ButtonStopProcess.UseVisualStyleBackColor = false;
            this.ButtonStopProcess.Click += new System.EventHandler(this.ButtonStopProcess_Click);
            // 
            // ButtonStartProcess
            // 
            this.ButtonStartProcess.BackColor = System.Drawing.Color.SeaGreen;
            this.ButtonStartProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonStartProcess.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonStartProcess.ForeColor = System.Drawing.Color.White;
            this.ButtonStartProcess.Location = new System.Drawing.Point(669, 522);
            this.ButtonStartProcess.Name = "ButtonStartProcess";
            this.ButtonStartProcess.Size = new System.Drawing.Size(107, 32);
            this.ButtonStartProcess.TabIndex = 36;
            this.ButtonStartProcess.Text = "Başlat";
            this.ButtonStartProcess.UseVisualStyleBackColor = false;
            this.ButtonStartProcess.Click += new System.EventHandler(this.ButtonStartProcess_Click);
            // 
            // ProgressBarGeneral
            // 
            this.ProgressBarGeneral.Location = new System.Drawing.Point(12, 544);
            this.ProgressBarGeneral.Name = "ProgressBarGeneral";
            this.ProgressBarGeneral.Size = new System.Drawing.Size(590, 10);
            this.ProgressBarGeneral.TabIndex = 38;
            // 
            // LabelDetailStatus
            // 
            this.LabelDetailStatus.AutoSize = true;
            this.LabelDetailStatus.BackColor = System.Drawing.Color.White;
            this.LabelDetailStatus.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LabelDetailStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.LabelDetailStatus.Location = new System.Drawing.Point(12, 522);
            this.LabelDetailStatus.Name = "LabelDetailStatus";
            this.LabelDetailStatus.Size = new System.Drawing.Size(52, 19);
            this.LabelDetailStatus.TabIndex = 39;
            this.LabelDetailStatus.Text = "Durum";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RadioButtonWriteNewFile);
            this.groupBox2.Controls.Add(this.RadioButtonWriteOnFile);
            this.groupBox2.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.groupBox2.Location = new System.Drawing.Point(620, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 75);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dosya İşlemi";
            // 
            // RadioButtonWriteNewFile
            // 
            this.RadioButtonWriteNewFile.AutoSize = true;
            this.RadioButtonWriteNewFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RadioButtonWriteNewFile.Location = new System.Drawing.Point(6, 42);
            this.RadioButtonWriteNewFile.Name = "RadioButtonWriteNewFile";
            this.RadioButtonWriteNewFile.Size = new System.Drawing.Size(142, 23);
            this.RadioButtonWriteNewFile.TabIndex = 1;
            this.RadioButtonWriteNewFile.Text = "Yeni dosya oluştur";
            this.RadioButtonWriteNewFile.UseVisualStyleBackColor = true;
            // 
            // RadioButtonWriteOnFile
            // 
            this.RadioButtonWriteOnFile.AutoSize = true;
            this.RadioButtonWriteOnFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RadioButtonWriteOnFile.Location = new System.Drawing.Point(6, 19);
            this.RadioButtonWriteOnFile.Name = "RadioButtonWriteOnFile";
            this.RadioButtonWriteOnFile.Size = new System.Drawing.Size(193, 23);
            this.RadioButtonWriteOnFile.TabIndex = 0;
            this.RadioButtonWriteOnFile.Text = "Aynı dosyanın üzerine yaz";
            this.RadioButtonWriteOnFile.UseVisualStyleBackColor = true;
            // 
            // ButtonTips
            // 
            this.ButtonTips.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ButtonTips.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonTips.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ButtonTips.Location = new System.Drawing.Point(727, 4);
            this.ButtonTips.Name = "ButtonTips";
            this.ButtonTips.Size = new System.Drawing.Size(123, 32);
            this.ButtonTips.TabIndex = 40;
            this.ButtonTips.Text = "Nasıl Kullanılır ?";
            this.ButtonTips.UseVisualStyleBackColor = false;
            this.ButtonTips.Click += new System.EventHandler(this.ButtonTips_Click);
            // 
            // ButtonExit
            // 
            this.ButtonExit.BackColor = System.Drawing.Color.IndianRed;
            this.ButtonExit.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ButtonExit.ForeColor = System.Drawing.Color.White;
            this.ButtonExit.Location = new System.Drawing.Point(856, 4);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(32, 32);
            this.ButtonExit.TabIndex = 41;
            this.ButtonExit.Text = "X";
            this.ButtonExit.UseVisualStyleBackColor = false;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.ButtonTips);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.LabelDetailStatus);
            this.Controls.Add(this.ProgressBarGeneral);
            this.Controls.Add(this.ButtonStopProcess);
            this.Controls.Add(this.ButtonStartProcess);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.LabelGeneralStatus);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.ButtonAllRemove);
            this.Controls.Add(this.ButtonSelectedRemove);
            this.Controls.Add(this.ButtonFolderSelect);
            this.Controls.Add(this.ButtonFileSelect);
            this.Controls.Add(this.DatagridViewFileList);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PictureBoxDragDropFiles);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PictureBoxBlueArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NGVault - AES-256 GCM File Encryption";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxBlueArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxDragDropFiles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DatagridViewFileList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxPasswordAgain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox CheckBoxPasswordUnseen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PictureBoxBlueArea;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox PictureBoxDragDropFiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RadioButtonDecrypt;
        private System.Windows.Forms.RadioButton RadioButtonCrypt;
        private System.Windows.Forms.RadioButton RadioButtonAutomaticSense;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DatagridViewFileList;
        private System.Windows.Forms.Button ButtonFileSelect;
        private System.Windows.Forms.Button ButtonFolderSelect;
        private System.Windows.Forms.Button ButtonSelectedRemove;
        private System.Windows.Forms.Button ButtonAllRemove;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label LabelGeneralStatus;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Button ButtonStopProcess;
        private System.Windows.Forms.Button ButtonStartProcess;
        private System.Windows.Forms.ProgressBar ProgressBarGeneral;
        private System.Windows.Forms.Label LabelDetailStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RadioButtonWriteNewFile;
        private System.Windows.Forms.RadioButton RadioButtonWriteOnFile;
        private System.Windows.Forms.Button ButtonTips;
        private System.Windows.Forms.Button ButtonExit;
    }
}

