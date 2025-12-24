using System.ComponentModel;

namespace NGVault
{
    public class FileItem : INotifyPropertyChanged
    {
        private string _path;
        private long _sizeBytes;
        private FileState _state;
        private string _result;

        public string Path { get => _path; set { _path = value; OnChanged(nameof(Path)); OnChanged(nameof(FileName)); } }
        public string FileName => System.IO.Path.GetFileName(_path);

        public long SizeBytes { get => _sizeBytes; set { _sizeBytes = value; OnChanged(nameof(SizeBytes)); OnChanged(nameof(SizeText)); } }
        public string SizeText => SizeBytes <= 0 ? "-" : $"{(SizeBytes / 1024d / 1024d):0.##} MB";

        public FileState State { get => _state; set { _state = value; OnChanged(nameof(State)); OnChanged(nameof(StateText)); } }
        public string StateText
        {
            get
            {
                switch (State)
                {
                    case FileState.Encrypted: return "Şifreli";
                    case FileState.Plain: return "Şifresiz";
                    default: return "Bilinmiyor";
                }
            }
        }

        public string Result { get => _result; set { _result = value; OnChanged(nameof(Result)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnChanged(string n) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }
}
