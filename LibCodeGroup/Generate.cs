using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace LibCodeGroup
{
    public static class Generate
    {
        public static string[] CodeGroup5Lookup()
        {
            HashSet<string> lookupHS = new HashSet<string>();
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            string[] lookup = new string[256];

            for (int i = 0; i < 256; i++)
            {
                if (!lookupHS.Add(CreateNew5Group(rng)))
                    i--;
            }
            for (int i = 0; i < 256; i++)
            {
                lookup[i] = lookupHS.ElementAt(i);
            }

            return lookup;
        }

        public static string[] CodeGroup2Lookup()
        {
            HashSet<string> lookupHS = new HashSet<string>();
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            string[] lookup = new string[256];

            for (int i = 0; i < 256; i++)
            {
                if (!lookupHS.Add(CreateNew2Group(rng)))
                    i--;
            }
            for (int i = 0; i < 256; i++)
            {
                lookup[i] = lookupHS.ElementAt(i);
            }

            return lookup;
        }

        private static string CreateNew5Group(RNGCryptoServiceProvider rng)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] bytes = new byte[1];
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 5; i++)
            {
                rng.GetBytes(bytes);
                int selection = (int)bytes[0] % chars.Length;
                sb.Append(chars[selection]);
            }

            return sb.ToString();
        }

        private static string CreateNew2Group(RNGCryptoServiceProvider rng)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] bytes = new byte[1];
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 2; i++)
            {
                rng.GetBytes(bytes);
                int selection = (int)bytes[0] % chars.Length;
                sb.Append(chars[selection]);
            }

            return sb.ToString();
        }
    }
}
