using System;

class CalculationModule
{
    static void Main(string[] args)
    {
        string strtDate = Console.ReadLine();
        string endDate = Console.ReadLine();
        int start = int.Parse(Console.ReadLine());

        string[] startComponents = strtDate.Split('.');
        string[] endComponents = endDate.Split('.');

        int[] startValues = new int[3];
        int[] endValues = new int[3];

        for (int i = 0; i < 3; i++)
        {
            startValues[i] = int.Parse(startComponents[i]);
            endValues[i] = int.Parse(endComponents[i]);
        }

        DateTime startDt = new DateTime(startValues[2], startValues[1], startValues[0]);
        DateTime endDt = new DateTime(endValues[2], endValues[1], endValues[0]);
        TimeSpan period = endDt - startDt;
        long daysInPeriod = period.Days;
        long totalProd = start * (daysInPeriod + 1) + (daysInPeriod * (daysInPeriod + 1)) / 2;
        Console.WriteLine(totalProd);
    }
}
