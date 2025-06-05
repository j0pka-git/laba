using System;

class World
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int[,] d = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                d[i, j] = (i == j) ? 0 : int.MaxValue;
            }
        }
        for (int k = 0; k < m; k++)
        {
            string[] edge = Console.ReadLine().Split();
            int a = int.Parse(edge[0]) - 1;
            int b = int.Parse(edge[1]) - 1;
            int w = int.Parse(edge[2]);

            d[a, b] = Math.Min(d[a, b], w);
            d[b, a] = Math.Min(d[b, a], w);
        }
        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (d[i, k] != int.MaxValue &&
                        d[k, j] != int.MaxValue &&
                        d[i, k] + d[k, j] < d[i, j])
                    {
                        d[i, j] = d[i, k] + d[k, j];
                    }
                }
            }
        }
        int max = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (d[i, j] != int.MaxValue)
                {
                    max = Math.Max(max, d[i, j]);
                }
            }
        }

        Console.WriteLine(max);
    }
}
