using System;

class Point
{
    public int X { get; private set; }
    public int Y { get; private set; }
    
    public delegate void BoundaryReachedHandler(Point point);
    public event BoundaryReachedHandler BoundaryReached;
    
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    public void Move(Rectangle bounds)
    {
        var rnd = new Random();
        X += rnd.Next(-5, 6);
        Y += rnd.Next(-5, 6);
        
        if (!bounds.Contains(X, Y))
        {
            BoundaryReached?.Invoke(this);
            // Возвращаем точку в границы
            X = Math.Clamp(X, bounds.MinX, bounds.MaxX);
            Y = Math.Clamp(Y, bounds.MinY, bounds.MaxY);
        }
    }
}

class Rectangle
{
    public int MinX { get; }
    public int MaxX { get; }
    public int MinY { get; }
    public int MaxY { get; }
    
    public Rectangle(int minX, int maxX, int minY, int maxY)
    {
        MinX = minX;
        MaxX = maxX;
        MinY = minY;
        MaxY = maxY;
    }
    
    public bool Contains(int x, int y) => 
        x >= MinX && x <= MaxX && 
        y >= MinY && y <= MaxY;
}

class Program
{
    static void Main()
    {
        var playArea = new Rectangle(-5, 5, -5, 5);
        var point = new Point(0, 0);
        point.BoundaryReached += OnBoundaryReached;
        
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Позиция {i}: ({point.X}, {point.Y})");
            point.Move(playArea);
        }
    }
    
    static void OnBoundaryReached(Point p) =>
        Console.WriteLine($"Точка ({p.X}, {p.Y}) вышла за границы!");
}
