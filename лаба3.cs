using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = "{[()]}";
        Console.WriteLine(Skobki(input) ? "Скобки сбалансированы" : "Скобки не сбалансированы");
    }

    static bool Skobki(string input)
    {
        var stack = new Stack<char>();
        foreach (char c in input)
        {
            if ("{[(".Contains(c)) stack.Push(c);
            else if ("}])".Contains(c))
            {
                if (stack.Count == 0 || !Sovpadaet(stack.Pop(), c)) 
                    return false;
            }
        }
        return stack.Count == 0;
    }

    static bool Sovpadaet(char open, char close) =>
        (open == '(' && close == ')') ||
        (open == '{' && close == '}') ||
        (open == '[' && close == ']');
}
