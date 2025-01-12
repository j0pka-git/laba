using System;
class World
{
    static int[] fmas(int[] massiv)
    {
        int i = 0;
        while (i < massiv.Length) { massiv[i] = Convert.ToInt32(Console.ReadLine()); i++; }
        return massiv;

    }

    static int krat3(int[] massivk)
    {
        int i = 0;
        int sum = 0;
        while (i < massivk.Length)
        {
            if (((massivk[i]) % 3) == 0) { sum += massivk[i]; }
            i++;
        }
        return sum;


    }
    static int multi(int[] massivp)
    {
        bool WW = false;
        int i = 0;
        int mlti = 1;
        while (i < massivp.Length)
        {
            if (((massivp[i]) % 2) == 1) { mlti *= massivp[i];WW = true; }
            i++;
        }
        if (WW) { return mlti; }
        else { return 0; }
    }
    static int @null(int[] massivn)
    {
        int i = 0;
        int knull = 0;
        while (i < massivn.Length)
        {
            if ((massivn[i]) == 0) { knull++; }
            i++;
        }
        return knull;

    }
    public static void Main()
    {

        Console.WriteLine("Введите количество элементов в 1 массиве");
        int c1 = Convert.ToInt32(Console.ReadLine());
        int[] massiv1 = new int[c1];
        massiv1 = fmas(massiv1);


        Console.WriteLine("Введите количество элементов в 2 массиве");
        int c2 = Convert.ToInt32(Console.ReadLine());
        int[] massiv2 = new int[c2];
        massiv2 = fmas(massiv2);

        Console.WriteLine("Введите количество элементов в 3 массиве");
        int c3 = Convert.ToInt32(Console.ReadLine());
        int[] massiv3 = new int[c3];
        massiv3 = fmas(massiv3);

        Console.WriteLine("сумма кратных 3:");
        Console.WriteLine("1. " + krat3(massiv1));
        Console.WriteLine("2. " + krat3(massiv2));
        Console.WriteLine("3. " + krat3(massiv3));
        Console.WriteLine("произведение нечет:");
        Console.WriteLine("1. " + multi(massiv1));
        Console.WriteLine("2. " + multi(massiv2));
        Console.WriteLine("3. " + multi(massiv3));
        Console.WriteLine("нули:");
        Console.WriteLine("1. " + @null(massiv1));
        Console.WriteLine("2. " + @null(massiv2));
        Console.WriteLine("3. " + @null(massiv3));
    }
}
