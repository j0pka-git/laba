using System;
using System.Collections.Generic;

class World
{
    static int MaxArea(int[] h)
    {
        var s = new Stack<int>();
        int max = 0;
        int len = h.Length;
        int[] bars = new int[len + 1];
        Array.Copy(h, bars, len);
        bars[len] = 0;

        for (int i = 0; i <= len; i++)
        {
            while (s.Count > 0 && bars[i] < bars[s.Peek()])
            {
                int idx = s.Pop();
                int height = bars[idx];
                int width = s.Count == 0 ? i : i - s.Peek() - 1;
                int area = width * height;
                if (area > max) max = area;
            }
            s.Push(i);
        }
        return max;
    }

    static void Main()
    {
        string[] p = Console.ReadLine().Split();
        int rows = int.Parse(p[0]);
        int cols = int.Parse(p[1]);
        int[,] grid = new int[rows, cols];

        int k = int.Parse(Console.ReadLine());
        for (int i = 0; i < k; i++)
        {
            p = Console.ReadLine().Split();
            int x = int.Parse(p[0]) - 1;
            int y = int.Parse(p[1]) - 1;
            grid[x, y] = 1;
        }

        int[] heights = new int[cols];
        int max = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                heights[j] = grid[i, j] == 0 ? heights[j] + 1 : 0;
            }
            max = Math.Max(max, MaxArea(heights));
        }
        Console.WriteLine(max);
    }
}
