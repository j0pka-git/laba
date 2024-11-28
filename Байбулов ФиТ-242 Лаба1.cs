using System;
class laba1
{
    static void Main()
    {
        //zad1
        int x, y;
        Console.WriteLine("Впишите 1-ое число");
        x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Впишите 2-ое число");
        y = Convert.ToInt32(Console.ReadLine());
        x = y - x;
        y = y - x;
        x = y + x;
        Console.WriteLine(x);
        Console.WriteLine(y);
        /*zad2
        int x, y;
        Console.WriteLine("Впишите 1-ое число");
        x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Впишите 2-ое число");
        y = Convert.ToInt32(Console.ReadLine());
        x = (x + y) - (Math.Abs(x - y));
        x = x / 2;
        Console.WriteLine("Наименьшим оказалось число  " + x);
        */


        /*zad3
                int m, l, n, k, dl,; //l - длина по которой проходят от одной грядки до другой
                Console.WriteLine("Введите ширину грядки");
                m = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите длину грядки");
                l = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите расстояние от колодца до первой грядки");
                k = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите количество грядок");
                n = Convert.ToInt32(Console.ReadLine());

                dl = (2 * k * n) + (2 * n * (l + m)) + (l * n * (n - 1));

                Console.WriteLine("Длина вашего пути составила " + dl);

        */
    }
}
