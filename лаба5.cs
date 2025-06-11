using System;
using System.Linq;
using System.Collections.Generic;

class PhoneRecord
{
    public string PhoneNumber { get; set; }
    public string ContactName { get; set; }
    public string MobileOperator { get; set; }
    
    public PhoneRecord(string phoneNumber, string contactName, string mobileOperator)
    {
        PhoneNumber = phoneNumber;
        ContactName = contactName;
        MobileOperator = mobileOperator;
    }
}

class Program
{
    static void Main()
    {
        var phoneRecords = new List<PhoneRecord>
        {
            new PhoneRecord("89888888888", "Vanya", "MTS"),
            new PhoneRecord("89888888888", "Vova", "Tele2"),
            new PhoneRecord("89888888888", "Ilik", "Tele2"),
            new PhoneRecord("89888888888", "Misha", "Beeline"),
            new PhoneRecord("89888888888", "Egor", "MTS")
        };

        var operatorStatistics = phoneRecords
            .GroupBy(record => record.MobileOperator)
            .ToDictionary(group => group.Key, group => group.Count());

        Console.WriteLine("Mobile operators statistics:");
        foreach (var stat in operatorStatistics)
        {
            Console.WriteLine($"{stat.Key}: {stat.Value} subscribers");
        }
    }
}
