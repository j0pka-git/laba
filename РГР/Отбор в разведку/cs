using System;

class World
{
    static int Group_Counter(int n)
    {
        if (n < 3 || n == 4) return 0;
        if (n == 3) return 1;

        int group1 = n / 2;
        int group2 = n - group1;

        return Group_Counter(group1) + Group_Counter(group2);
    }

    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine(Group_Counter(n));
    } 

}
