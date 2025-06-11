using System;
using System.Collections.Generic;

class Car
{
    public int Year { get; }
    public string Mark { get; }
    public bool IsClean { get; set; }
    
    public Car(int year, string mark, bool isClean)
    {
        Year = year;
        Mark = mark;
        IsClean = isClean;
    }
}

class Garage
{
    public List<Car> Cars { get; } = new List<Car>();
}

class CarWash
{
    public static void Wash(Car car)
    {
        if (car.IsClean)
        {
            Console.WriteLine($"Машина {car.Mark} уже чистая!");
            return;
        }
        
        car.IsClean = true;
        Console.WriteLine($"Машина {car.Mark} успешно помыта!");
    }
}

delegate void CarWashDelegate(Car car);

class Program
{
    static void Main()
    {
        try
        {
            var garage = new Garage();
            
            Console.Write("Введите количество машин: ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.Write($"\nМашина #{i+1}\nМарка: ");
                string mark = Console.ReadLine();
                
                Console.Write("Год выпуска: ");
                int year = int.Parse(Console.ReadLine());
                
                Console.Write("Чистая? (1 - да, 0 - нет): ");
                bool isClean = Console.ReadLine() == "1";
                
                garage.Cars.Add(new Car(year, mark, isClean));
            }

            CarWashDelegate wash = CarWash.Wash;
            
            Console.WriteLine("\nПроцесс мойки:");
            foreach (var car in garage.Cars)
            {
                wash(car);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка ввода данных!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}
