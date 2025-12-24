using System;

namespace NGVault
{
    public class NGVaultWrongPasswordException : Exception
    {
        public NGVaultWrongPasswordException() : base("Şifre yanlış veya veri doğrulanamadı.") { }
    }

    public class NGVaultCorruptedDataException : Exception
    {
        public NGVaultCorruptedDataException(string msg) : base(msg) { }
    }

    public class NGVaultNotEncryptedException : Exception
    {
        public NGVaultNotEncryptedException() : base("Dosya NGVault formatında şifreli değil.") { }
    }
}