using System;
class World
{
    static void Main()
    {
        int MaxN = Convert.ToInt32(Console.ReadLine());
        int per = MaxN;
        for (int K = 3; K <= MaxN; K = 2 * K + 1)
        {
            int Z;
            Z = MaxN / K;
            per += Z;
        }
        Console.WriteLine(per);
    }
}
