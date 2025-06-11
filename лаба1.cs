using System;
using System.Linq;

class Subscriber
{
    public string Name { get; set; }
    public Phone[] Phones { get; set; }
    public string City { get; set; }

    public Subscriber(string name, Phone[] phones, string city)
    {
        Name = name;
        Phones = phones;
        City = city;
    }

    public override string ToString() => 
        $"\nName: {Name} | Numbers: {string.Join(", ", Phones.Select(p => p.Number))} | City: {City}";
}

class Phone
{
    public string Number { get; set; }
    public string Operator { get; set; }
    public int Year { get; set; }

    public Phone(string number, string oper, int year)
    {
        Number = number;
        Operator = oper;
        Year = year;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Number of subscribers: ");
        var subscribers = new Subscriber[int.Parse(Console.ReadLine())];
        
        while (true)
        {
            Console.WriteLine("\n\tMenu\n1. Fill data\n2. Search by name\n3. Search by operator\n4. Search by number\n5. Exit");
            
            switch (Console.ReadLine())
            {
                case "1": FillData(subscribers); break;
                case "2": Search(subscribers, "name"); break;
                case "3": Search(subscribers, "operator"); break;
                case "4": Search(subscribers, "number"); break;
                case "5": return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }

    static void FillData(Subscriber[] subscribers)
    {
        for (int i = 0; i < subscribers.Length; i++)
        {
            Console.Write($"\nFull name of subscriber #{i+1}: ");
            string name = Console.ReadLine();

            Console.Write("Number of phones: ");
            var phones = new Phone[int.Parse(Console.ReadLine())];
            
            for (int j = 0; j < phones.Length; j++)
            {
                Console.Write("Phone number: ");
                string number = Console.ReadLine();
                Console.Write("Year: ");
                int year = int.Parse(Console.ReadLine());
                Console.Write("Operator: ");
                phones[j] = new Phone(number, Console.ReadLine(), year);
            }

            Console.Write("City: ");
            subscribers[i] = new Subscriber(name, phones, Console.ReadLine());
        }
    }

    static void Search(Subscriber[] subscribers, string searchType)
    {
        Console.Write($"\nEnter {searchType}: ");
        string searchTerm = Console.ReadLine();
        
        var results = subscribers.Where(sub =>
            searchType == "name" ? sub.Name == searchTerm :
            searchType == "operator" ? sub.Phones.Any(p => p.Operator == searchTerm) :
            sub.Phones.Any(p => p.Number == searchTerm)
        ).ToArray();

        Console.WriteLine(results.Length == 0 ? "Not found" : string.Join("", results));
    }
}
