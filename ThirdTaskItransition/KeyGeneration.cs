using System.Security.Cryptography;
using System.Text; 

namespace ThirdTaskItransition
{
    internal class KeyGeneration
    { 

        public string GenerateKey()
        {
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {  
                byte[] randomUnsignedInteger32Bytes = new byte[32];
                rng.GetBytes(randomUnsignedInteger32Bytes);
                var randomInt32 = BitConverter.ToString(randomUnsignedInteger32Bytes);

                //Console.WriteLine(randomInt32.ToString());
                return randomInt32.ToString().Replace("-","");
            }
            
        } 
         
        public string GenerateHMAC(string choise, string key)
        {
            using (var hmacsha256 = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            { 
                var result = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(choise));

                return BitConverter.ToString(result).Replace("-","");
            }
        }

    }
}
