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


        Console.WriteLine("Сумма цифр каждого из элементов представлена последовательностью: ");
        for (int i = 0; i < n; i++)
        {
            int sum = 0;
            int j = Math.Abs(array[i]);
            for (; j > 0; j = j / 10)
            {
                sum += j % 10;
            }
            Console.WriteLine(sum);
        }
    }
}
