using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Xml;
namespace XYECOM.Core
{
    /// <summary>
    /// 安全处理通用类
    /// </summary>
    public class SecurityUtil
    {
        private static byte[] IV = null;
        static SecurityUtil()
        {
            IV = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x0b, 0x54, 0x07, 0x08, 0x09, 0x10, 0xf1, 0x12, 0x13, 0x14, 0x15, 0xff };
        }

        #region Des
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="value">加密串</param>
        /// <param name="key">密钥</param>
        /// <param name="Iv">加密初始化向量</param>
        /// <returns></returns>
        public static string DESDecrypt(string value, string key, string Iv)
        {
            Byte[] rgbKey = new Byte[8];
            Array.Copy(Encoding.UTF8.GetBytes(key.PadRight(rgbKey.Length)), rgbKey, rgbKey.Length);
            Byte[] rgbIv = new Byte[8];
            Array.Copy(Encoding.UTF8.GetBytes(Iv.PadRight(rgbIv.Length)), rgbIv, rgbIv.Length);


            DESCryptoServiceProvider encryptor = new DESCryptoServiceProvider();
            ICryptoTransform transform = encryptor.CreateDecryptor(rgbKey, rgbIv);

            byte[] buffer = Convert.FromBase64String(value);

            MemoryStream stream = new MemoryStream();

            try
            {
                using (CryptoStream cryptostream = new CryptoStream(stream, transform, CryptoStreamMode.Write))
                {
                    cryptostream.Write(buffer, 0, buffer.Length);
                }

                return Encoding.UTF8.GetString(stream.ToArray());
            }
            catch (CryptographicException)
            {
                throw new CryptographicException("Unable to decrypt data, >>key or inintialization vector maybe invalid!");
            }
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="rgbKey">密钥</param>
        /// <param name="regIv">初始化向量</param>
        /// <returns></returns>
        public static string DESEncrypt(string value, string key, string Iv)
        {
            Byte[] rgbKey = new Byte[8];
            Array.Copy(Encoding.UTF8.GetBytes(key.PadRight(rgbKey.Length)), rgbKey, rgbKey.Length);
            Byte[] rgbIv = new Byte[8];
            Array.Copy(Encoding.UTF8.GetBytes(Iv.PadRight(rgbIv.Length)), rgbIv, rgbIv.Length);

            DESCryptoServiceProvider encryptor = new DESCryptoServiceProvider();
            ICryptoTransform transform = encryptor.CreateEncryptor(rgbKey, rgbIv);

            byte[] buffer = Encoding.UTF8.GetBytes(value);

            MemoryStream stream = new MemoryStream();

            try
            {
                using (CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(buffer, 0, buffer.Length);
                }

                return Convert.ToBase64String(stream.ToArray());
            }
            catch (CryptographicException)
            {
                throw new CryptographicException("Unable to encrypt data, >> key or inintialization vector maybe invalid!");
            }
        }

        #endregion

        #region md5
        /// <summary>
        /// 字符串加密
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5(string str,string md5value)
        {
            if (md5value == "16")
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                string text16 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(str)), 4, 8);
                text16 = text16.Replace("-", "");
                return text16;
            }

            byte[] bytes = Encoding.Default.GetBytes(str);
            bytes = new MD5CryptoServiceProvider().ComputeHash(bytes);
            string text = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                text = text + bytes[i].ToString("x").PadLeft(2, '0');
            }
            return text;
        }
        #endregion

        #region Shr256

        public static string SHA256(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            SHA256Managed managed = new SHA256Managed();
            return Convert.ToBase64String(managed.ComputeHash(bytes));
        }
        #endregion

        #region Aes

        /// <summary>
        /// AES 加密
        /// </summary>
        /// <param name="Data">数据</param>
        /// <param name="Key">密钥</param>
        /// <param name="IV">初始化向量</param>
        /// <returns></returns>
        public static string AESEncrypt(String Data, byte[] Key)
        {
            try
            {
                Byte[] _data = Encoding.UTF8.GetBytes(Data);

                Rijndael RijndaelAlg = Rijndael.Create();

                MemoryStream memory = new MemoryStream();

                CryptoStream cStream = new CryptoStream(memory,
                    RijndaelAlg.CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write);

                try
                {
                    cStream.Write(_data, 0, _data.Length);
                    cStream.FlushFinalBlock();


                    return Convert.ToBase64String(memory.ToArray());

                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: {0}", e.Message);
                }
                finally
                {
                    memory.Close();
                    cStream.Close();
                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("A file error occurred: {0}", e.Message);
            }
            return "";
        }

        /// <summary>
        /// AES 解密
        /// </summary>
        /// <param name="Data">密文</param>
        /// <param name="Key">密钥</param>
        /// <param name="IV">初始化向量</param>
        /// <returns></returns>
        public static string AESDecrypt(String Data, byte[] Key)
        {
            try
            {
                Byte[] _data = Convert.FromBase64String(Data);

                Rijndael RijndaelAlg = Rijndael.Create();

                MemoryStream memory = new MemoryStream(_data);

                CryptoStream cStream = new CryptoStream(memory,
                    RijndaelAlg.CreateDecryptor(Key, IV),
                    CryptoStreamMode.Read);

                string val = null;

                try
                {
                    // 明文存储区
                    using (MemoryStream originalMemory = new MemoryStream())
                    {
                        Byte[] Buffer = new Byte[1024];
                        Int32 readBytes = 0;
                        while ((readBytes = cStream.Read(Buffer, 0, Buffer.Length)) > 0)
                        {
                            originalMemory.Write(Buffer, 0, readBytes);
                        }

                        val = Encoding.UTF8.GetString(originalMemory.ToArray());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: {0}", e.Message);
                }
                finally
                {
                    cStream.Close();
                }

                return val;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("A file error occurred: {0}", e.Message);
                return null;
            }
        }
        #endregion
    }
}
