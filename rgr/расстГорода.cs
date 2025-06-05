using System;

class World
{
    static double ToRadians(double degrees)
    {
        return (degrees * Math.PI) / 180;
    }

    static void Main()
    {
        string firstLine = Console.ReadLine();
        string secondLine = Console.ReadLine();

        var coords1 = firstLine.Split(" ");
        double latitude1 = double.Parse(coords1[0]);
        double longitude1 = double.Parse(coords1[1]);

        var coords2 = secondLine.Split(" ");
        double latitude2 = double.Parse(coords2[0]);
        double longitude2 = double.Parse(coords2[1]);

        double lat1Rad = ToRadians(latitude1);
        double lon1Rad = ToRadians(longitude1);
        double lat2Rad = ToRadians(latitude2);
        double lon2Rad = ToRadians(longitude2);

        double deltaLon = Math.Abs(lon1Rad - lon2Rad);
        double centralAngle = Math.Acos(
            Math.Sin(lat1Rad) * Math.Sin(lat2Rad) +
            Math.Cos(lat1Rad) * Math.Cos(lat2Rad) * Math.Cos(deltaLon)
        );

        double radius = double.Parse(Console.ReadLine());
        double distance = radius * centralAngle;

        Console.WriteLine($"{distance:F3}");
    }
}
