using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaziraBusinessLayer.DLL.Security.Interface
{
   public interface ISecurity
    {
       string Encrypt(string password);
       string Decrypt(string dcpassword);
    }
}
