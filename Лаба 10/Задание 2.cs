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

            string stroka, str;
            stroka = Console.ReadLine();
            string[] words = stroka.Split(' ');
            string[] otvet = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                string normik = "";
                str = words[i];
                for (var j = str.Length - 1; j > 0; j--)
                {
                    normik += str[j];
                }
                if ((normik + str[0]) == words[i])
                {
                    Console.WriteLine("Ïàëèíäðîì : " + str);
                }

            }

        }
    }
}
