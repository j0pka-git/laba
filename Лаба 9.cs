using System;
class laba9
{
    static int[][] zxc(int[][] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int a = int.Parse(Console.ReadLine());
            array[i] = new int[a];
            for (int j = 0; j < a; j++)
            {
                array[i][j] = int.Parse(Console.ReadLine());
            }
        }
        return array;
    }
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[][] array = new int[n][];
        array = zxc(array);
        for (int i = 0; i < n; i++)
        {
            int c = 0; 
            int num = array[i].Length;
            for (int j = 0; j < num; j++)
            {
                if (j != 0 && array[i][j] < array[i][j - 1]) c++;
                
                if (c + 1 == num) Console.WriteLine("номер: " +(i + 1));
                
            }
        }
    }
}
