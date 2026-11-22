using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    // Введення яхт з клавіатури
    static List<Boat> InputFromKeyboard()
    {
        int n = Boat.ReadInt("Кількість яхт у регаті: ", 0, int.MaxValue);

        List<Boat> boats = new List<Boat>();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"--- Яхта № {i + 1} ---");
            Boat y = Boat.Input();
            boats.Add(y);
        }
        return boats;
    }

    // Читання яхт з текстового файла (одна яхта в рядку)
    static List<Boat> LoadFromFile(string path)
    {
        List<Boat> boats = new List<Boat>();
        if (!File.Exists(path))
        {
            Console.WriteLine($"Файл {path} не знайдено.");
            return boats;
        }

        using (StreamReader reader = new StreamReader(path))
        {
            int lineNumber = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                lineNumber++;
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                try
                {
                    Boat b = Boat.Parse(line);
                    boats.Add(b);
                }
                catch (FormatException e)
                {
                    // Некоректний рядок пропускаємо, але повідомляємо про нього
                    Console.WriteLine($"Рядок {lineNumber} пропущено: {e.Message}");
                }
            }
        }
        return boats;
    }

    // Виведення яхт кожного класу (на екран або у файл)
    static void PrintByClass(List<Boat> boats, TextWriter w)
    {
        for (int k = 0; k < Boat.Classes.Length; k++)
        {
            w.WriteLine($"Клас {Boat.Classes[k]}:");
            List<Boat> sel = boats
                .Where(y => y.BoatClass == Boat.Classes[k])
                .OrderBy(y => y.Place)
                .ToList();
            for (int j = 0; j < sel.Count; j++)
            {
                sel[j].Print(w);
            }
        }
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Джерело даних:\n    1 - клавіатура\n    2 - файл input.txt");
        Console.Write("Ваш вибір: ");
        string choice = Console.ReadLine();

        List<Boat> boats;
        if (choice == "2")
            boats = LoadFromFile("input.txt");
        else
            boats = InputFromKeyboard();

        Console.WriteLine("\nРезультати регати за класами:");
        PrintByClass(boats, Console.Out);

        using (var writer = new StreamWriter("output.txt"))
        {
            writer.WriteLine("Результати регати за класами:");
            PrintByClass(boats, writer);
        }
        Console.WriteLine("Результат записано в output.txt");
    }
}

public class Boat
{
    public static readonly string[] Classes = { "Фін", "Зоряний", "Торнадо", "Солинг" };

    public string Name { get; set; }        // назва яхти
    public string BoatClass { get; set; }   // клас яхти
    public int Crew { get; set; }           // екіпаж
    public string Port { get; set; }        // порт приписки
    public int Place { get; set; }          // місце в класі

    private Boat(string name, string boatClass, int crew, string port, int place)
    {
        Name = name;
        BoatClass = boatClass;
        Crew = crew;
        Port = port;
        Place = place;
    }

    // Введення даних про яхту з клавіатури
    public static Boat Input()
    {
        Console.Write("Назва яхти: ");
        var name = Console.ReadLine();

        Console.WriteLine("Клас яхти:");
        for (var i = 0; i < Classes.Length; i++)
            Console.WriteLine($"  {i + 1} - {Classes[i]}");
        int k = ReadInt($"Оберіть номер класу (1-{Classes.Length}): ", 1, Classes.Length);

        int crew = ReadInt("Кількість членів екіпажу: ", 1, int.MaxValue);

        Console.Write("Порт приписки: ");
        string port = Console.ReadLine();

        int place = ReadInt("Місце в класі за результатами регати: ", 1, int.MaxValue);

        return new Boat(name, Classes[k - 1], crew, port, place);
    }

    // Читання цілого числа з клавіатури, доки не буде введено коректне значення
    public static int ReadInt(string prompt, int min, int max)
    {
        int value;
        string text;
        do
        {
            Console.Write(prompt);
            text = Console.ReadLine();
        } while (!int.TryParse(text, out value) || value < min || value > max);
        return value;
    }

    // Створення яхти з рядка файла (назва;клас;екіпаж;порт;місце)
    public static Boat Parse(string line)
    {
        string[] p = line.Split(';');
        if (p.Length != 5)
            throw new FormatException("очікується 5 полів через ';'");

        // Шукаємо клас без урахування регістру і зберігаємо його стандартну назву
        string boatClass = Classes.FirstOrDefault(
            c => string.Equals(c, p[1].Trim(), StringComparison.OrdinalIgnoreCase));
        if (boatClass == null)
            throw new FormatException($"невідомий клас яхти \"{p[1].Trim()}\"");

        if (!int.TryParse(p[2], out int crew) || crew < 1)
            throw new FormatException($"некоректний екіпаж \"{p[2].Trim()}\"");
        if (!int.TryParse(p[4], out int place) || place < 1)
            throw new FormatException($"некоректне місце \"{p[4].Trim()}\"");

        return new Boat(p[0].Trim(), boatClass, crew, p[3].Trim(), place);
    }

    // Виведення інформації про яхту на екран або у файл
    public void Print(TextWriter writer)
    {
        writer.WriteLine($"  {Place}. {Name,-10} екіпаж {Crew}, порт {Port}");
    }
}
