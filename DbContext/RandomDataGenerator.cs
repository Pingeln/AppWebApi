using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContext
{
    public class RandomDataGenerator
    {
        private readonly Random _random = new Random();

        /// <summary>
        /// Generates a random string with the given length.
        /// </summary>
        /// <param name="length">The length of the string.</param>
        /// <returns>A random string.</returns>
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[length];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[_random.Next(chars.Length)];
            }

            return new string(stringChars);
        }

        /// <summary>
        /// Generates a random number between the given minimum and maximum values.
        /// </summary>
        /// <param name="min">The minimum value (inclusive).</param>
        /// <param name="max">The maximum value (exclusive).</param>
        /// <returns>A random number.</returns>
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}