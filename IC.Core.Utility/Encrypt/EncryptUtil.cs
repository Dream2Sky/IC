using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace IC.Core.Utility.Encrypt
{
    public class EncryptUtil
    {
        public static string Sha1(string plainText, Encoding encoding)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_in = encoding.GetBytes(plainText);
            byte[] bytes_out = sha1.ComputeHash(bytes_in);
            sha1.Dispose();
            string result = BitConverter.ToString(bytes_out);
            result = result.Replace("-", "");
            return result;
        }

        public static string MD5_32(string plainText, Encoding encoding)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytes = encoding.GetBytes(plainText);
            string result = BitConverter.ToString(md5.ComputeHash(bytes));
            return result.Replace("-", "");
        }

        public static string MD5_16(string plainText, Encoding encoding)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytes = encoding.GetBytes(plainText);
            string result = BitConverter.ToString(md5.ComputeHash(bytes), 4, 8);
            return result.Replace("-", "");
        }
    }
}
