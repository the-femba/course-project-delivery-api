using System;
using System.Linq;

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
        /// <returns>Сгенерированная строка, или плэвок в @бало</returns>
        public static string GenerateString(string mask = "", int length = 32, Random? inRandom = null)
        {
            Random random = inRandom ?? new Random();

            return new string(Enumerable.Range(0, length).Select(n => (char)random.Next(32, 127)).ToArray());
        }
    }
}
