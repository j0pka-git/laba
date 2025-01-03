using System;

class World
{
    static int Group_Counter(int n)
    {
        if (n < 3 || n == 4) return 0;
        if (n == 3) return 1;

        int g1 = n / 2;
        int g2 = n - g1;

        return Group_Counter(g1) + Group_Counter(g2);
    }

    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine(Group_Counter(n));
    } 

}
