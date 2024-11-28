using System;
class laba2
{
    static void Main()
    {
        //zad1
        Console.WriteLine("Введите количество чисел");
        int a = Convert.ToInt32(Console.ReadLine());
        int k;
        int j = 0; // счетчик положительных
        Console.WriteLine("Вводите числа");
        for (int i = 1 ; i <= a; i++)
        {
            k = Convert.ToInt32(Console.ReadLine());
            if (k < 0) { j++; }

        }
        Console.WriteLine("Количество чисел меньше нуля оказалось равным "+j);

        /*zad2
        Console.WriteLine("Введите количество элементов");
        int a = Convert.ToInt32(Console.ReadLine()); 
        int MAX = 0;
        int max = 0;
        Console.WriteLine("Вводите значения");
        for (int i = 1, j = 0; i <= a; i++)
        {
            j = Convert.ToInt32(Console.ReadLine());
            if (i == 1) MAX = max = j;
            else if (i == 2)
            {
                if (j > MAX) MAX = j;
                else max = j;
            }
            else if (j > MAX) 
            { 
                max = MAX; 
                MAX = j; 
            }

        }
        Console.WriteLine("Значение второго максимального элемента равно "+max);
        */

        /*zad3
        int num = Convert.ToInt32(Console.ReadLine());
        int k = 0;
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        for (int i = 2; i < num; i++)
        {
            int c = Convert.ToInt32(Console.ReadLine());
            if (b < a && b < c)
            {
                k++;
            }
            a = b;
            b = c;
        }
        Console.WriteLine(k);
        */

    }

}


        

