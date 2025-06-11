using System;
using System.Linq;
using System.Collections.Generic;

class Phone
{
    public string Number { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Operator { get; set; }

    public Phone(string number, string name, DateTime date, string oper)
    {
        Number = number;
        Name = name;
        Date = date;
        Operator = oper;
    }
}

class Program
{
    static void AddPhones(List<Phone> phones, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nВведите номер телефона {i + 1}-го владельца: ");
            string number = Console.ReadLine();
            Console.WriteLine($"Введите ФИО {i + 1}-го владельца: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Введите дату постановки на учет {i + 1}-го владельца (дд.мм.гггг): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine($"Введите оператора связи {i + 1}-го владельца: ");
            string oper = Console.ReadLine();
            phones.Add(new Phone(number, name, date, oper));
        }
    }

    static void Main()
    {
        List<Phone> phones = new List<Phone>();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n1. Заполнить данные.");
            Console.WriteLine("2. Выборка по ФИО.");
            Console.WriteLine("3. Выборка по номеру телефона.");
            Console.WriteLine("4. Вывести данные, сгруппированные по году.");
            Console.WriteLine("5. Вывести данные, сгруппированные по оператору.");
            Console.WriteLine("6. Выход.");
            Console.WriteLine("Введите операцию: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("\nОшибка ввода. Попробуйте снова.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nВведите количество владельцев: ");
                    if (int.TryParse(Console.ReadLine(), out int count))
                        AddPhones(phones, count);
                    else
                        Console.WriteLine("\nНекорректный ввод.");
                    break;
                case 2:
                    Console.WriteLine("\nВведите ФИО для выборки: ");
                    string name = Console.ReadLine();
                    var byName = phones.Where(p => p.Name == name);
                    PrintPhones(byName);
                    break;
                case 3:
                    Console.WriteLine("\nВведите номер телефона для выборки: ");
                    string number = Console.ReadLine();
                    var byNumber = phones.Where(p => p.Number == number);
                    PrintPhones(byNumber);
                    break;
                case 4:
                    var byYear = phones.GroupBy(p => p.Date.Year).OrderBy(g => g.Key);
                    PrintGroupedPhones(byYear, "Год");
                    break;
                case 5:
                    var byOperator = phones.GroupBy(p => p.Operator).OrderBy(g => g.Key);
                    PrintGroupedPhones(byOperator, "Оператор");
                    break;
                case 6:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("\nТакой операции не существует.");
                    break;
            }
        }
    }

    static void PrintPhones(IEnumerable<Phone> phones)
    {
        foreach (var phone in phones)
        {
            Console.WriteLine($"\nНомер: {phone.Number}, ФИО: {phone.Name}, Дата: {phone.Date:dd.MM.yyyy}, Оператор: {phone.Operator}");
        }
    }

    static void PrintGroupedPhones(IEnumerable<IGrouping<object, Phone>> groups, string groupName)
    {
        foreach (var group in groups)
        {
            Console.WriteLine($"\n{groupName}: {group.Key}");
            PrintPhones(group);
        }
    }
}
