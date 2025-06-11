using System;
using System.Collections.Generic;
using System.Linq;

class Racer
{
    public string Name { get; }
    public int Speed { get; set; }
    public int Position { get; set; }
    
    public Racer(string name, int speed)
    {
        Name = name;
        Speed = speed;
        Position = 0;
    }
}

class Race
{
    private readonly List<Racer> _racers;
    private readonly int _finishLine;
    private readonly Random _random = new Random();
    
    public delegate void RaceFinishedHandler(Racer winner, int time);
    public event RaceFinishedHandler RaceFinished;
    
    public Race(List<Racer> racers, int finishLine)
    {
        _racers = racers;
        _finishLine = finishLine;
    }
    
    public void StartRace(int interval)
    {
        int time = 0;
        while (true)
        {
            // Изменяем скорость с заданным интервалом
            if (time % interval == 0)
            {
                _racers.ForEach(r => 
                    r.Speed = Math.Max(1, r.Speed + _random.Next(-2, 3)));
            }
            
            // Двигаем всех участников
            _racers.ForEach(r => r.Position += r.Speed);
            
            // Проверяем победителя
            var winner = _racers.FirstOrDefault(r => r.Position >= _finishLine);
            if (winner != null)
            {
                RaceFinished?.Invoke(winner, time + 1);
                return;
            }
            
            time++;
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Длина трассы (метров): ");
            int trackLength = int.Parse(Console.ReadLine());
            
            Console.Write("Интервал изменения скорости (секунд): ");
            int interval = int.Parse(Console.ReadLine());
            
            var racers = new List<Racer>
            {
                new Racer("Стрела", 12),
                new Racer("Молния", 15),
                new Racer("Ветер", 10)
            };
            
            var race = new Race(racers, trackLength);
            race.RaceFinished += OnRaceFinished;
            
            Console.WriteLine("\nУчастники гонки:");
            racers.ForEach(r => Console.WriteLine($"{r.Name}: стартовая скорость {r.Speed} м/с"));
            
            Console.WriteLine("\nГонка началась!");
            race.StartRace(interval);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
    
    static void OnRaceFinished(Racer winner, int time) =>
        Console.WriteLine($"\nПобедитель: {winner.Name}!\n" +
                         $"Финишировал за {time} секунд\n" +
                         $"Средняя скорость: {winner.Position / (float)time:F1} м/с");
}
