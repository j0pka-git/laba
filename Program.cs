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

        int k = 0;
        for (int i = 0; i < n - 1; i++)
        {
            if (array[i + 1] > array[i]) k++;
        }
        if (k != n - 1) Console.WriteLine("Последовательность невозрастающая");
        if (k == n - 1) Console.WriteLine("Последовательность возрастающая");

    }
}