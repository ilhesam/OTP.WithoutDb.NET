using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTP.WithoutDb.NET.Helpers
{
    public static class RandomCodeGenerator
    {
        public static string GenerateRandomCode(int length, IList<char> permittedLetters)
        {
            var random = new Random();
            var strBuilder = new StringBuilder();
            var lettersLastIndex = permittedLetters.Count - 1;

            for (int i = 0; i < length; i++)
            {
                var rndIndex = random.Next(lettersLastIndex);
                strBuilder.Append(permittedLetters[rndIndex]);
            }

            return strBuilder.ToString();
        }

        public static string GenerateRandomCode(int length, char[] permittedLetters)
            => GenerateRandomCode(length, permittedLetters.ToList());
    }
}