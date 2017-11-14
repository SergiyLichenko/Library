using System;
using System.Linq;
using System.Text;
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
            string result = securedValue.Aggregate(String.Empty, (current, b) => current + $"{b:x2}");

            return new Guid(result);
        }
    }
}
