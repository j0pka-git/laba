using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stroc, per = "";
            stroc = Console.ReadLine();
            for (int i = 0; i < stroc.Length; i++)
            {
                if (i != 0 && stroc[i - 1] != stroc[i])
                {
                    per += stroc[i - 1];

                }
                else if (i != 0 && stroc[i - 1] == stroc[i] && stroc[i - 1] != ' ')
                {
                    per += stroc[i - 1];
                }
            }
            Console.WriteLine(per);
            Console.ReadLine();
        }
    }
}
