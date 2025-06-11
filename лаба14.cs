using System;
using System.Linq;
using System.Collections.Generic;

record Provider(int Id, string Name, string Number, string City);
record Product(int Id, string Name);
record Movement(int ProductId, int ProviderId, int Quantity, int Price, string Date, bool IsComing);

class Program
{
    static void Main()
    {
        var providers = new List<Provider>
        {
            new(1, "provider1", "+7904", "Omsk"),
            new(2, "provider2", "+7950", "Moscow")
        };

        var products = new List<Product>
        {
            new(1, "product1"),
            new(2, "product2")
        };

        var movements = new List<Movement>
        {
            new(1, 1, 5, 200, "20.05.2025", true),
            new(2, 2, 12, 2000, "20.06.2025", true),
            new(1, 2, 3, 12, "29.05.2025", false),
            new(2, 1, 27, 512, "20.04.2025", true)
        };

        while (true)
        {
            Console.WriteLine("\n\tМеню");
            Console.WriteLine("1. Количество остатков товара в магазине");
            Console.WriteLine("2. Сгруппировать поставки товара по дате");
            Console.WriteLine("3. Сгруппировать поставки товара по поставщику");
            Console.WriteLine("4. Выдать движение товара сгруппированного по артикулу");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите пункт меню: ");

            if (!int.TryParse(Console.ReadLine(), out var choice))
            {
                Console.WriteLine("Ошибка ввода. Попробуйте снова.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    ShowProductBalances(products, movements);
                    break;
                case 2:
                    ShowDeliveriesByDate(products, movements);
                    break;
                case 3:
                    ShowDeliveriesByProvider(products, providers, movements);
                    break;
                case 4:
                    ShowProductMovements(products, providers, movements);
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Неверный ввод. Введите число от 1 до 5.");
                    break;
            }
        }
    }

    static void ShowProductBalances(List<Product> products, List<Movement> movements)
    {
        var balances = movements
            .GroupBy(m => m.ProductId)
            .Join(products,
                g => g.Key,
                p => p.Id,
                (g, p) => new
                {
                    p.Name,
                    Balance = g.Sum(x => x.IsComing ? x.Quantity : -x.Quantity)
                });

        Console.WriteLine("\nОстатки товаров:");
        foreach (var item in balances)
        {
            Console.WriteLine($"{item.Name}: {item.Balance} штук");
        }
    }

    static void ShowDeliveriesByDate(List<Product> products, List<Movement> movements)
    {
        var deliveries = movements
            .Where(m => m.IsComing)
            .GroupBy(m => m.Date)
            .OrderBy(g => g.Key);

        Console.WriteLine("\nПоставки товаров по датам:");
        foreach (var group in deliveries)
        {
            Console.WriteLine($"Дата: {group.Key}");
            foreach (var m in group)
            {
                var product = products.First(p => p.Id == m.ProductId);
                Console.WriteLine($"Товар: {product.Name}, Количество: {m.Quantity}, Цена: {m.Price}");
            }
        }
    }

    static void ShowDeliveriesByProvider(List<Product> products, List<Provider> providers, List<Movement> movements)
    {
        var providerDeliveries = movements
            .Where(m => m.IsComing)
            .GroupBy(m => m.ProviderId)
            .Join(providers,
                g => g.Key,
                p => p.Id,
                (g, p) => new
                {
                    p.Name,
                    Movements = g
                });

        Console.WriteLine("\nПоставки товаров по поставщикам:");
        foreach (var group in providerDeliveries)
        {
            Console.WriteLine($"Поставщик: {group.Name}");
            foreach (var m in group.Movements)
            {
                var product = products.First(p => p.Id == m.ProductId);
                Console.WriteLine($"Товар: {product.Name}, Дата: {m.Date}, Количество: {m.Quantity}, Цена: {m.Price}");
            }
        }
    }

    static void ShowProductMovements(List<Product> products, List<Provider> providers, List<Movement> movements)
    {
        var productMovements = movements
            .GroupBy(m => m.ProductId)
            .Join(products,
                g => g.Key,
                p => p.Id,
                (g, p) => new
                {
                    p.Name,
                    Movements = g
                })
            .OrderBy(x => x.Name);

        Console.WriteLine("\nДвижение товаров:");
        foreach (var group in productMovements)
        {
            Console.WriteLine($"Товар: {group.Name}");
            foreach (var m in group.Movements)
            {
                var provider = providers.First(p => p.Id == m.ProviderId);
                var operation = m.IsComing ? "Поступление" : "Продажа";
                Console.WriteLine($"{operation}, Поставщик: {provider.Name}, Дата: {m.Date}, Количество: {m.Quantity}, Цена: {m.Price}");
            }
        }
    }
}
