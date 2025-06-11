using System;
using System.Linq;
using System.Collections.Generic;

record Computer(int Id, string Name, string Model, string OS);

record User(int Id, string FullName, bool HasComputer, Computer? Computer)
{
    public override string ToString() => HasComputer 
        ? $"Пользователь: {FullName}, Компьютер: {Computer?.Name}, Модель: {Computer?.Model}, ОС: {Computer?.OS}"
        : $"Пользователь: {FullName}, Компьютер: Отсутствует";
}

class Program
{
    static readonly List<User> Users = new()
    {
        new(1, "Daniil", true, new Computer(1, "Asus", "TUF", "Windows 11")),
        new(2, "Dima", true, new Computer(2, "Asus", "Vivo", "Windows 10")),
        new(3, "Matvey", false, null),
        new(4, "Egor", true, new Computer(3, "Acer", "Nitro", "Windows 11")),
        new(5, "Artem", true, new Computer(4, "MSI", "Pro", "Linux")),
        new(6, "Nikita", false, null)
    };

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n\tМеню");
            Console.WriteLine("1. Пользователи без компьютера (по алфавиту)");
            Console.WriteLine("2. Пользователи по операционной системе");
            Console.WriteLine("3. Пользователи по модели компьютера (по алфавиту)");
            Console.WriteLine("4. Выход");
            Console.Write("Выберите действие: ");

            if (!int.TryParse(Console.ReadLine(), out var choice))
            {
                Console.WriteLine("Ошибка ввода! Попробуйте снова.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    ShowUsersWithoutComputer();
                    break;
                case 2:
                    ShowUsersByOS();
                    break;
                case 3:
                    ShowUsersByComputerModel();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static void ShowUsersWithoutComputer()
    {
        var users = Users
            .Where(u => !u.HasComputer)
            .OrderBy(u => u.FullName)
            .ToList();

        Console.WriteLine("\nПользователи без компьютера:");
        users.ForEach(Console.WriteLine);
    }

    static void ShowUsersByOS()
    {
        Console.Write("\nВведите ОС для поиска: ");
        var os = Console.ReadLine();

        var users = Users
            .Where(u => u.HasComputer && u.Computer?.OS.Equals(os, StringComparison.OrdinalIgnoreCase) == true)
            .ToList();

        if (users.Any())
        {
            Console.WriteLine($"\nПользователи с ОС {os}:");
            users.ForEach(Console.WriteLine);
        }
        else
        {
            Console.WriteLine("Пользователи с указанной ОС не найдены.");
        }
    }

    static void ShowUsersByComputerModel()
    {
        Console.Write("\nВведите модель компьютера: ");
        var model = Console.ReadLine();

        var users = Users
            .Where(u => u.HasComputer && u.Computer?.Name.Equals(model, StringComparison.OrdinalIgnoreCase) == true)
            .OrderBy(u => u.FullName)
            .ToList();

        if (users.Any())
        {
            Console.WriteLine($"\nПользователи с компьютером {model}:");
            users.ForEach(Console.WriteLine);
        }
        else
        {
            Console.WriteLine("Пользователи с указанной моделью компьютера не найдены.");
        }
    }
}
