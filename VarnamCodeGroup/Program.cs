using LibCodeGroup;
using LibVernam;
using System;
using System.Text;

namespace VarnamCodeGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            string textToBeEncrypted = "This is a string of text.";
            byte[] bytesToBeEncrypted = Encoding.ASCII.GetBytes(textToBeEncrypted);
            byte[] key = Helpers.GenerateRandomBytes(bytesToBeEncrypted.Length);

            byte[] cipherText = Vernam.Encrypt(bytesToBeEncrypted, key);

            string codedFile = CodeGroup.ConvertToCode(cipherText);
            byte[] decodefile = CodeGroup.ConvertFromCode(codedFile);


            string textDeciphered = Encoding.ASCII.GetString(Vernam.Decrypt(decodefile, key));

            Console.WriteLine(textDeciphered);
        }
    }
}
