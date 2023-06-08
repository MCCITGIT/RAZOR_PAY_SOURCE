using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Encryption
/// </summary>
public static class Encryption
{
    //public static string encrypt(string encryptString)
    //{
    //    try
    //    {
    //        if (!string.IsNullOrEmpty(encryptString))
    //        {
    //            string EncryptionKey = string.IsNullOrEmpty(ConfigurationManager.AppSettings["EncryptionKey"]) ? string.Empty : ConfigurationManager.AppSettings["EncryptionKey"];
    //            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
    //            using (Aes encryptor = Aes.Create())
    //            {
    //                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
    //                encryptor.Key = pdb.GetBytes(32);
    //                encryptor.IV = pdb.GetBytes(16);
    //                using (MemoryStream ms = new MemoryStream())
    //                {
    //                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
    //                    {
    //                        cs.Write(clearBytes, 0, clearBytes.Length);
    //                        cs.Close();
    //                    }
    //                    encryptString = Convert.ToBase64String(ms.ToArray());
    //                }
    //            }
    //            return HttpUtility.UrlEncode(encryptString);
    //        }
    //        else
    //        {
    //            return string.Empty;
    //        }
    //    }
    //    catch (Exception)
    //    {
    //        return string.Empty;
    //    }

    //}

    //public static string Decrypt(string cipherText)
    //{
    //    try
    //    {
    //        if (!string.IsNullOrEmpty(cipherText))
    //        {
    //            cipherText = HttpUtility.UrlDecode(cipherText);

    //            string EncryptionKey = string.IsNullOrEmpty(ConfigurationManager.AppSettings["EncryptionKey"]) ? string.Empty : ConfigurationManager.AppSettings["EncryptionKey"];
    //            cipherText = cipherText.Replace(" ", "+");
    //            byte[] cipherBytes = Convert.FromBase64String(cipherText);
    //            using (Aes encryptor = Aes.Create())
    //            {
    //                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
    //                encryptor.Key = pdb.GetBytes(32);
    //                encryptor.IV = pdb.GetBytes(16);
    //                using (MemoryStream ms = new MemoryStream())
    //                {
    //                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
    //                    {
    //                        cs.Write(cipherBytes, 0, cipherBytes.Length);
    //                        cs.Close();
    //                    }
    //                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
    //                }
    //            }
    //            return cipherText;
    //        }
    //        else
    //        {
    //            return string.Empty;
    //        }
    //    }
    //    catch (Exception)
    //    {
    //        return string.Empty;
    //    }
    //}

    public static string encrypt(string input)
    {
        var plainTextBytes = Encoding.UTF8.GetBytes(input);
        return Convert.ToBase64String(plainTextBytes);
    }
    public static string Decrypt(string input)
    {
        try
        {
            var base64EncodedBytes = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
        catch
        {
            return string.Empty;
        }
    }
}