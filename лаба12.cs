using System;
using System.IO;
using System.Collections.Generic;

class FileNumberFilter
{
    static void Main()
    {
        string inputFilePath = @"C:\Users\DaniilMS\Desktop\input.txt";
        string outputFilePath = @"C:\Users\DaniilMS\Desktop\output.txt";

        string[] allLines = File.ReadAllLines(inputFilePath);
        var linesWithEvenNumbers = new List<string>();

        foreach (var line in allLines)
        {
            string currentNumber = "";

            foreach (var character in line)
            {
                if (char.IsDigit(character))
                {
                    currentNumber += character;
                }
                else if (currentNumber.Length > 0)
                {
                    if (IsEvenNumber(currentNumber))
                    {
                        linesWithEvenNumbers.Add(line);
                        break;
                    }
                    currentNumber = "";
                }
            }

            if (currentNumber.Length > 0 && IsEvenNumber(currentNumber))
            {
                linesWithEvenNumbers.Add(line);
            }
        }

        File.WriteAllLines(outputFilePath, linesWithEvenNumbers);
    }

    static bool IsEvenNumber(string numberString)
    {
        return int.Parse(numberString) % 2 == 0;
    }
}
