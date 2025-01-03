using System;

class World
{
    static int GrpCount(int n)
    {
        if (n < 3 || n == 4) return 0;
        if (n == 3) return 1;

        int g1 = n / 2;
        int g2 = n - g1;

        return GrpCount(g1) + GrpCount(g2);
    }

    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(GrpCount(n));
    }

}
