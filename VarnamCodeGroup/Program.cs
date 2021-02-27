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

            byte[] cipherText = Vernam.Encrypt(bytesToBeEncrypted, key);  //Encrypt

            string codedCipherText = CodeGroup.ConvertToCode(cipherText); //Encode
            byte[] decodedCipherText = CodeGroup.ConvertFromCode(codedCipherText);  //Decode

            byte[] decipheredFile = Vernam.Decrypt(decodedCipherText, key); //Decrypt
            string textDeciphered = Encoding.ASCII.GetString(decipheredFile);

            Console.WriteLine(textDeciphered);
        }
    }
}
