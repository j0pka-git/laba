using System;

class MathCalculator
{
    public int FirstOperand { get; }
    public int SecondOperand { get; }
    
    public MathCalculator(int firstOperand, int secondOperand)
    {
        FirstOperand = firstOperand;
        SecondOperand = secondOperand;
    }
    
    public int Add() => FirstOperand + SecondOperand;
    public int Subtract() => FirstOperand - SecondOperand;
    public int Multiply() => FirstOperand * SecondOperand;
    public int Divide() => SecondOperand == 0 ? throw new DivideByZeroException("Division by zero is not allowed") : FirstOperand / SecondOperand;
}

delegate int CalculationOperation();

class Program
{
    static int AddThenSubtractSecondOperand(MathCalculator calculator) => calculator.Add() - calculator.SecondOperand;
    static int MultiplyAddSubtractSecondOperand(MathCalculator calculator) => AddThenSubtractSecondOperand(calculator) * calculator.SecondOperand;
    static int DivideThenAddSecondOperand(MathCalculator calculator) => calculator.Divide() + calculator.SecondOperand;
    static int MultiplyDivideAddSecondOperand(MathCalculator calculator) => DivideThenAddSecondOperand(calculator) * calculator.SecondOperand;

    static void Main()
    {
        try
        {
            Console.WriteLine("Enter two numbers:");
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            var calculator1 = new MathCalculator(firstNumber, secondNumber);
            var calculator2 = new MathCalculator(firstNumber, secondNumber);

            // Создаем и наполняем делегаты
            CalculationOperation operationChain1 = calculator1.Add;
            operationChain1 += () => AddThenSubtractSecondOperand(calculator1);
            operationChain1 += () => MultiplyAddSubtractSecondOperand(calculator1);

            CalculationOperation operationChain2 = calculator2.Divide;
            operationChain2 += () => DivideThenAddSecondOperand(calculator2);
            operationChain2 += () => MultiplyDivideAddSecondOperand(calculator2);

            // Выполняем операции и выводим результаты
            ExecuteAndPrintResults("Results for the first operation chain:", operationChain1);
            ExecuteAndPrintResults("\nResults for the second operation chain:", operationChain2);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Invalid input. Please enter valid integers.");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ExecuteAndPrintResults(string message, CalculationOperation calculationChain)
    {
        Console.WriteLine(message);
        foreach (CalculationOperation operation in calculationChain.GetInvocationList())
        {
            try
            {
                Console.WriteLine(operation());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during operation execution: {ex.Message}");
            }
        }
    }
}
