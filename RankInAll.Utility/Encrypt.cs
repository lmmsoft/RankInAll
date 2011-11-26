using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RankInAll.Utility
{
    public static class Encrypt
    {
        public static string Base64Encode(this string data)
        {
            byte[] encbuff = System.Text.Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(encbuff);
        }

        public static string Base64Decode(this string data)
        {
            byte[] decbuff = Convert.FromBase64String(data);
            return System.Text.Encoding.UTF8.GetString(decbuff);
        }
    }
}
