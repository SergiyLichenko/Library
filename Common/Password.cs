using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Common
{
    public static class Password
    {
        public static Guid GetHashText(string s)
        {
            byte[] byteValue = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider csp = new MD5CryptoServiceProvider();
            byte[] securedValue = csp.ComputeHash(byteValue);
            string result = String.Empty;

            foreach (byte b in securedValue)
            {
                result += String.Format("{0:x2}", b);
            }
            return new Guid(result);
        }
    }
}
