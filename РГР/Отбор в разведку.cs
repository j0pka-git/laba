using System;
class World
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int GrpCount = CountGroups(n);
        Console.WriteLine(GrpCount);
    }

    static int CountGroups(int n)
    {
        if (n < 3) return 0;
        if (n == 3) return 1;

        int g1 = n / 2; 
        int g2 = n - g1; 

        return CountGroups(g1) + CountGroups(g2);
    }
}
