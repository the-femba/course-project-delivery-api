using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Flx.Delivery.Application.Utils
{
    public static class StringUtil
    {
        /// <summary>
        /// Генирирует случайную строку
        /// </summary>
        /// <param name="mask">Маска, или выборка, по которой будет происходить генерациия</param>
        /// <param name="length">Количество символов</param>
        /// <param name="inRandom">Свой, или создать рандом</param>
        /// <returns>Сгенерированная строка</returns>
        public static string GenerateString(string mask = "", int length = 32, Random? inRandom = null)
        {
            Random random = inRandom ?? new Random();

            return new string(Enumerable.Range(0, length).Select(n => (char)random.Next(32, 127)).ToArray());
        }

        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();

            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
