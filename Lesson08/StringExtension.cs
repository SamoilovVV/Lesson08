using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson08.Extensions
{
    public static class StringExtension
    {
        public static int NumberOfVowels(this string str)
        {
            // Создаём массив гласных букв
            char[] vowels = { 'e', 'y', 'u', 'i', 'o', 'a', 'у', 'е', 'ы', 'а', 'о', 'э', 'я', 'и', 'ю', 'й' };
            int count = 0;
            // Приводим нашу строку к нижнему регистру и преобразовываем в массив символов char
            foreach (char i in str.ToLower().ToCharArray())
            {
                // Каждый символ строки сравниваем с гласной
                for (int j = 0; j < vowels.Length; j++)
                {
                    if (i == vowels[j])
                        count++;
                }
            }

            return count;
        }

        public static int CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }

            return counter;
        }

        public static int IndexOf(this string str, char c)
        {
            int i = 0;
            // Код
            return i;
        }
        
    }
}
