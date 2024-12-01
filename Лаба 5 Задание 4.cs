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
        
        
        double summa = 0, srar = 0;
        for (int i = 0; i < n ; i++)
        {
            summa += array[i];
        }
        srar = summa / n;
        Console.WriteLine("Ср.ар. равно "+srar);
        

        
    }
}
