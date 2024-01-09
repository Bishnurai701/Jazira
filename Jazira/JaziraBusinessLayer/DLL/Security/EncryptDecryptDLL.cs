using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JaziraBusinessLayer.DLL.Security.Interface;

namespace JaziraBusinessLayer.DLL.Security
{
  public class EncryptDecryptDLL:ISecurity
    {
      public string Encrypt(string password)
      {
          string strmsg = string.Empty;
          byte[] encode = new byte[password.Length];
          encode = Encoding.UTF8.GetBytes(password);
          strmsg = Convert.ToBase64String(encode);
          return strmsg;
      }
      public string Decrypt(string dcpassword)
      {
          string decryptpw = string.Empty;
          UTF8Encoding encodepw = new UTF8Encoding();
          Decoder Decode = encodepw.GetDecoder();
          byte[] todecode_byte = Convert.FromBase64String(dcpassword);
          int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
          char[] decoded_char = new char[charCount];
          Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
          decryptpw = new String(decoded_char);
          return decryptpw;
      }
    }
}
