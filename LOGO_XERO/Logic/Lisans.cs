using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LOGO_XERO.Logic
{
    public class Lisans
    {
        private static byte[] _salt = Encoding.ASCII.GetBytes("o6806642kbM7c5");


        public LOGO_XERO_LISANS lisans()
        {
            try
            {

                LOGO_XERO_LISANS AL = new LOGO_XERO_LISANS();
                AL.TARIH = DateTime.Now.ToString();
                AL.MODUL = 1;
                AL.VERGIKIMLIKNO = "DVF";
                return AL;
            }
            catch
            {
                return null;
            }
        }

        public LOGO_XERO_LISANS LisansKontrolEt(string key)
        {
            LOGO_XERO_LISANS lisans = new LOGO_XERO_LISANS();
            try
            {
                string VERGINO = "";
                string MODUL = "";
                string TARIH = "";
                string cevrilmis = AES(key, "HST");
                VERGINO = cevrilmis.Split('+')[0];
                TARIH = cevrilmis.Split('+')[1];
                MODUL = cevrilmis.Split('+')[2];

                lisans.MODUL = Convert.ToInt32(MODUL);
                lisans.TARIH = TARIH;
                lisans.VERGIKIMLIKNO = VERGINO;
                return lisans;
            }
            catch
            {
                return lisans;
            }



        }
        public string SifreleAES(string sifrelencekMetin, string sharedSecret)
        {
            if (string.IsNullOrEmpty(sifrelencekMetin))
                throw new ArgumentNullException("plainText");
            if (string.IsNullOrEmpty(sharedSecret))
                throw new ArgumentNullException("sharedSecret");

            string outStr = null;
            RijndaelManaged aesAlg = null;

            try
            {

                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    msEncrypt.Write(BitConverter.GetBytes(aesAlg.IV.Length), 0, sizeof(int));
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(sifrelencekMetin);
                        }
                    }
                    outStr = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            finally
            {

                if (aesAlg != null)
                    aesAlg.Clear();
            }
            return outStr;
        }

        /// <summary>
        /// EncryptStringAES() ile şifrelenen metnin şifresini çözer.
        /// <param name="cipherText">Deşifre edilecek metin uzmanim.net</param>
        /// <param name="sharedSecret">Paylaşılan gizli anahtar</param>
        private static string AES(string cipherText, string sharedSecret)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException("cipherText");
            if (string.IsNullOrEmpty(sharedSecret))
                throw new ArgumentNullException("sharedSecret");


            RijndaelManaged aesAlg = null;


            string plaintext = null;

            try
            {

                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);


                byte[] bytes = Convert.FromBase64String(cipherText);
                using (MemoryStream msDecrypt = new MemoryStream(bytes))
                {

                    aesAlg = new RijndaelManaged();
                    aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                    aesAlg.IV = ReadByteArray(msDecrypt);

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))

                            //uzmanim.net
                            plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            catch
            {
                return "";
            }
            finally
            {

                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return plaintext;
        }

        private static byte[] ReadByteArray(Stream s)
        {
            byte[] rawLength = new byte[sizeof(int)];
            if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
            {
                throw new SystemException("Stream did not contain properly formatted byte array");
            }

            byte[] buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                throw new SystemException("Did not read byte array properly");
            }

            return buffer;
        }

        public int KalanGunDondur(string Tarih, int modul)
        {
            DateTime lisanstarihialmi = Convert.ToDateTime(Tarih);
            DateTime lisansBitisTarihi = new DateTime();
            if (modul == 4)
            {
                lisansBitisTarihi = lisanstarihialmi.AddMonths(6);
            }
            else
            {
                lisansBitisTarihi = lisanstarihialmi.AddYears(1);
            }
            TimeSpan gun = lisansBitisTarihi - DateTime.Now;
            return gun.Days;
        }
        public string tarihdondur(string lisansno)
        {
            string donustur = AES(lisansno, "HST");
            string parca = donustur.Split('+')[1];
            DateTime kayittarihi = Convert.ToDateTime(parca);
            DateTime sontarih = kayittarihi.AddYears(1);
            TimeSpan gun = sontarih - DateTime.Now;
            return gun.Days.ToString();
        }

        public List<REGISTERALANLAR> Registeralan()
        {
            List<REGISTERALANLAR> liste = new List<REGISTERALANLAR>();
            liste.Add(new REGISTERALANLAR { ADI = "DBNAME", TIP = typeof(System.String) });
            liste.Add(new REGISTERALANLAR { ADI = "PASSWORD", TIP = typeof(System.String) });
            liste.Add(new REGISTERALANLAR { ADI = "SERVERNAME", TIP = typeof(System.String) });
            liste.Add(new REGISTERALANLAR { ADI = "USERNAME", TIP = typeof(System.String) });
            liste.Add(new REGISTERALANLAR { ADI = "KULLANICIID", TIP = typeof(System.String) });
            liste.Add(new REGISTERALANLAR { ADI = "FIRMANO", TIP = typeof(System.String) });
            liste.Add(new REGISTERALANLAR { ADI = "DONEMNO", TIP = typeof(System.String) });
            liste.Add(new REGISTERALANLAR { ADI = "Skin", TIP = typeof(System.String) });
            return liste;

        }
    }

    public class REGISTERALANLAR
    {
        public string ADI { get; set; }
        public Type TIP { get; set; }
    }

    public class LOGO_XERO_LISANS   //MODÜL 1 TEKLİF MODÜL 2 gööz 3 tam paket 4 demo
    {
        public int MODUL { get; set; }
        public string VERGIKIMLIKNO { get; set; }
        public string TARIH { get; set; }
    }


}
