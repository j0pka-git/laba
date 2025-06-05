using System;
using System.Collections.Generic;

class SuperHorse
{
    static readonly int[] horseX = { 2, 1, -1, -2, -2, -1, 1, 2 };
    static readonly int[] horseY = { 1, 2, 2, 1, -1, -2, -2, -1 };
    static readonly int[] kingX = { 0, 0, 1, -1 };
    static readonly int[] kingY = { 1, -1, 0, 0 };

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string[] coords = Console.ReadLine().Split();
        int sx = int.Parse(coords[0]);
        int sy = int.Parse(coords[1]);
        int tx = int.Parse(coords[2]);
        int ty = int.Parse(coords[3]);

        int ans = Solve(n, sx, sy, tx, ty);
        Console.WriteLine(ans == -1 ? "NO" : ans.ToString());
    }

    static int Solve(int n, int sx, int sy, int tx, int ty)
    {
        var q = new Queue<(int x, int y, int s)>();
        var vis = new bool[n + 1, n + 1];

        q.Enqueue((sx, sy, 0));
        vis[sx, sy] = true;

        while (q.Count > 0)
        {
            var (x, y, s) = q.Dequeue();

            if (x == tx && y == ty)
                return s;

            bool black = (x + y) % 2 == 0;
            int[] dx = black ? horseX : kingX;
            int[] dy = black ? horseY : kingY;
            int cnt = black ? 8 : 4;

            for (int i = 0; i < cnt; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];

                if (nx >= 1 && nx <= n &&
                    ny >= 1 && ny <= n &&
                    !vis[nx, ny])
                {
                    vis[nx, ny] = true;
                    q.Enqueue((nx, ny, s + 1));
                }
            }
        }

        return -1;
    }
}
