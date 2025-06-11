using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var input = Console.ReadLine()?.Split(' ') ?? Array.Empty<string>();
        if (input.Length != 3)
        {
            Console.WriteLine("Неверное количество элементов");
            return;
        }

        if (!int.TryParse(input[0], out int num1) || !int.TryParse(input[1], out int num2))
        {
            Console.WriteLine("Неверный формат чисел");
            return;
        }

        var stack = new Stack<int>();
        stack.Push(num1);
        stack.Push(num2);

        switch (input[2])
        {
            case "+":
                Console.WriteLine(stack.Pop() + stack.Pop());
                break;
            case "-":
                Console.WriteLine(-stack.Pop() + stack.Pop());
                break;
            case "*":
                Console.WriteLine(stack.Pop() * stack.Pop());
                break;
            case "/":
                if (stack.Peek() == 0)
                    Console.WriteLine("Делить на ноль нельзя");
                else
                    Console.WriteLine(1f / stack.Pop() * stack.Pop());
                break;
            default:
                Console.WriteLine("Неверная операция");
                break;
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var list = new List<char> { 'a', 'b', 'c', 'a', 'c' };
        
        Console.WriteLine("Уникальные символы:");
        Console.WriteLine(string.Join("\n", new HashSet<char>(list)));
        
        Console.WriteLine("\nЧастота символов:");
        list.GroupBy(c => c)
            .ToList()
            .ForEach(g => Console.WriteLine($"{g.Key}: {g.Count()}"));
    }
}
