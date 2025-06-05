using System;

class HullArea
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        int[] xs = new int[count];
        int[] ys = new int[count];

        for (int i = 0; i < count; i++)
        {
            string[] parts = Console.ReadLine().Split();
            xs[i] = int.Parse(parts[0]);
            ys[i] = int.Parse(parts[1]);
        }

        ArrangePoints(xs, ys, count);

        int[] hullXs = new int[2 * count];
        int[] hullYs = new int[2 * count];
        int hullSize = BuildHull(xs, ys, count, hullXs, hullYs);

        double area = GetArea(hullXs, hullYs, hullSize);
        Console.WriteLine(area.ToString("F1"));
    }

    static int Cross(int x0, int y0, int x1, int y1, int x2, int y2)
    {
        int dx1 = x1 - x0;
        int dy1 = y1 - y0;
        int dx2 = x2 - x0;
        int dy2 = y2 - y0;
        return dx1 * dy2 - dy1 * dx2;
    }

    static void ArrangePoints(int[] xs, int[] ys, int n)
    {
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (xs[j] > xs[j + 1] || (xs[j] == xs[j + 1] && ys[j] > ys[j + 1]))
                {
                    (xs[j], xs[j + 1]) = (xs[j + 1], xs[j]);
                    (ys[j], ys[j + 1]) = (ys[j + 1], ys[j]);
                }
            }
        }
    }

    static int BuildHull(int[] xs, int[] ys, int n, int[] hx, int[] hy)
    {
        int top = 0;
        for (int i = 0; i < n; i++)
        {
            while (top >= 2 && Cross(hx[top - 2], hy[top - 2], hx[top - 1], hy[top - 1], xs[i], ys[i]) <= 0)
                top--;

            hx[top] = xs[i];
            hy[top] = ys[i];
            top++;
        }

        int lower = top;
        for (int i = n - 2; i >= 0; i--)
        {
            while (top > lower && Cross(hx[top - 2], hy[top - 2], hx[top - 1], hy[top - 1], xs[i], ys[i]) <= 0)
                top--;

            hx[top] = xs[i];
            hy[top] = ys[i];
            top++;
        }

        return top - 1;
    }

    static double GetArea(int[] xs, int[] ys, int n)
    {
        double total = 0;
        for (int i = 0; i < n; i++)
        {
            int next = (i + 1) % n;
            total += xs[i] * ys[next] - xs[next] * ys[i];
        }
        return Math.Abs(total) / 2.0;
    }
}

