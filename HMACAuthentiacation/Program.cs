using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HMACAuthentiacation
{
    //GeneratedClientAppIDAPPKey
    class Program
    {
        static void Main(string[] args)
        {
            using (var cryptoProvider = new RNGCryptoServiceProvider())
            {
                var APPID = Guid.NewGuid();
                byte[] secretKeyByteArray = new byte[32]; //256 bit
                cryptoProvider.GetBytes(secretKeyByteArray);
                var APIKey = Convert.ToBase64String(secretKeyByteArray);
            }
        }
    }
}
