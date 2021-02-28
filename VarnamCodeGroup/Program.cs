using LibCodeGroup;
using LibVernam;
using System;
using System.Text;

namespace VernamCodeGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            string textToBeEncrypted = "This is a string of text.";
            byte[] bytesToBeEncrypted = Encoding.ASCII.GetBytes(textToBeEncrypted);
            byte[] key = Helpers.GenerateRandomBytes(bytesToBeEncrypted.Length);

            byte[] cipherText = Vernam.Encrypt(bytesToBeEncrypted, key);  //Encrypt

            string[] lookup = CodeGroup.GenerateLookup();  //Create a random lookup table for the encoder

            string codedCipherText = CodeGroup.ConvertToCode(cipherText); //Encode
            byte[] decodedCipherText = CodeGroup.ConvertFromCode(codedCipherText);  //Decode

            byte[] decipheredText = Vernam.Decrypt(decodedCipherText, key); //Decrypt
            string textThatWasEncrypted = Encoding.ASCII.GetString(decipheredText);

            Console.WriteLine(textThatWasEncrypted);

            Console.ReadLine();
        }
    }
}
