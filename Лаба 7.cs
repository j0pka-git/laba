using System;
class laba7
{
    static int nechot(int[] array, int count = 0)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int k = array[i];
            if (k % 2 != 0)
            {
                count += 1;
            }
        }
        return count;
    }
    static void Main()
    {
        int count = 0, perv, sec, tretiy, nechcount = 0;
        int a = 0, b = 0, c = 0;
        Console.WriteLine("Вводите размерности");
        perv = int.Parse(Console.ReadLine());
        sec = int.Parse(Console.ReadLine());
        tretiy = int.Parse(Console.ReadLine());
        int[][] array0 = new int[3][];
        array0[0] = new int[perv];
        array0[1] = new int[sec];
        array0[2] = new int[tretiy];
        for (int i = 0; i < perv; i++)
        {
            array0[0][i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < sec; i++)
        {
            array0[1][i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < tretiy; i++)
        {
            array0[2][i] = int.Parse(Console.ReadLine());
        }
        a = nechot(array0[0]);
        b = nechot(array0[1]);
        c = nechot(array0[2]);
        nechcount = a + b + c;
        Console.WriteLine("нечет в 1: "+a);
        Console.WriteLine("нечет во 2: "+b);
        Console.WriteLine("нечет в 3: "+c);
        Console.WriteLine("общ: "+nechcount);
    }
}
