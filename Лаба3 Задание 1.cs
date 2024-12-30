using System;
class laba3
{
    static void Main()
    {

        //zad1

        int k, c = 0, max = 0, y = 1, t;
        k = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < k; i++)
        {
            t = Convert.ToInt32(Console.ReadLine());
            if (i != 0 & c == t) y++;
            
            if (y > max) max = y;
            
            else
            {
                y = 1;
            }
            c = t;
        }
        Console.WriteLine(max);
    }
}
