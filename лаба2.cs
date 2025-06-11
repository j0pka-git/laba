using System;

class Shape { public string Name { get; set; } }
interface IFormula { double Perimeter(); double Area(); }

class Circle : Shape, IFormula
{
    public double Radius;
    public double Perimeter() => 2 * Math.PI * Radius;
    public double Area() => Math.PI * Radius * Radius;
}

class Square : Shape, IFormula
{
    public double Side;
    public double Perimeter() => 4 * Side;
    public double Area() => Side * Side;
}

class Triangle : Shape, IFormula
{
    public double Side;
    public double Perimeter() => 3 * Side;
    public double Area() => Math.Sqrt(3) * Side * Side / 4;
}

class Program
{
    static void Main()
    {
        var circle = new Circle { Name = "Circle", Radius = GetInput("circle radius") };
        var square = new Square { Name = "Square", Side = GetInput("square side length") };
        var triangle = new Triangle { Name = "Triangle", Side = GetInput("triangle side length") };

        PrintResults(circle);
        PrintResults(square);
        PrintResults(triangle);
    }

    static double GetInput(string prompt)
    {
        Console.WriteLine($"Enter {prompt}:");
        return double.Parse(Console.ReadLine());
    }

    static void PrintResults(IFormula shape)
    {
        Console.WriteLine($"\nShape: {(shape as Shape).Name}");
        Console.WriteLine($"Perimeter: {shape.Perimeter():F2}");
        Console.WriteLine($"Area: {shape.Area():F2}");
    }
}
