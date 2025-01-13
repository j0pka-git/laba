using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            string stroka, str;
            stroka = Console.ReadLine();
            string[] words = stroka.Split(' ');
            string[] otvet = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                str = words[i];
                if (str[0] == str[str.Length - 1])
                {
                    count++;
                }

            }
            Console.WriteLine("Êîëè÷åñòâî ñëîâ : " + count);

        }
    }
}
