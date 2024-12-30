using System;
using System.Runtime.Serialization.Formatters;
class laba5
{
    static void Main()
    {
        Console.WriteLine("Введите количество элемнтов");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        Console.WriteLine("Введите значения элементов");
        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        int k3 = 0;
        for (int i = 0; i < n; i++)
        {
            if (Math.Abs(array[i]) % 10 == 3) k3++;
        }
        Console.WriteLine("Количество элементов оканчивающихся на тройку равно " + k3);
    }
}
