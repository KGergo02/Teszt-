using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Teszt__.src.Models
{
    public static class JelszoTitkosito
    {
        private const string fo_kulcs = "82fbc88b170b6fe7fa47c7f6a5e23e63";

        private static TripleDESCryptoServiceProvider GetCryproProvider()
        {
            var md5_biztosito = new MD5CryptoServiceProvider();

            var kulcs = md5_biztosito.ComputeHash(Encoding.UTF8.GetBytes(fo_kulcs));

            return new TripleDESCryptoServiceProvider() { Key = kulcs, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };
        }

        public static string Encrypt(string jelszo)
        {
            var adat = Encoding.UTF8.GetBytes(jelszo);

            var felulet = GetCryproProvider();

            var atalakit = felulet.CreateEncryptor();

            var vegeredmenyek_tomb = atalakit.TransformFinalBlock(adat, 0, adat.Length);

            return Convert.ToBase64String(vegeredmenyek_tomb);
        }

        public static string Decrypt(string titkositottSzoveg)
        {
            var data = Convert.FromBase64String(titkositottSzoveg);

            var felulet = GetCryproProvider();

            var atalakit = felulet.CreateDecryptor();

            var vegeredmenyek_tomb = atalakit.TransformFinalBlock(data, 0, data.Length);

            return Encoding.UTF8.GetString(vegeredmenyek_tomb);
        }
    }
}
