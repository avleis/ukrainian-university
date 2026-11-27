using System.Globalization;

namespace LaboratoryWork10.Common;

public static class ConsoleInput
{
    public static int ReadInt(string prompt = "")
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            // null означає, що введення закінчилось (наприклад, Ctrl+D) — далі читати нічого
            if (input == null)
            {
                Environment.Exit(0);
            }

            if (int.TryParse(input, out int integer))
            {
                return integer; 
            }

            Console.WriteLine("Некоректне введення. Введіть ціле число.");
        }
    }
    
    public static int ReadIntInRange(string prompt, int min, int max)
    {
        while (true)
        {
            int number = ReadInt(prompt);

            if (number >= min && number <= max)
            {
                return number;
            }

            Console.WriteLine($"Некоректне введення. Введіть число від {min} до {max}.");
        }
    }

    public static double ReadDouble(string prompt = "")
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (input == null)
            {
                Environment.Exit(0);
            }

            // приймаємо і кому, і крапку: замінюємо кому на крапку і читаємо в інваріантній культурі
            input = input.Replace(',', '.');

            if (double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out double number) && !double.IsNaN(number) && !double.IsInfinity(number))
            {
                return number; 
            }

            Console.WriteLine("Некоректне введення. Введіть число.");
        }
    }
    
    public static DateTime ReadDate(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            // null означає, що введення закінчилось (наприклад, Ctrl+D) — далі читати нічого
            if (input == null)
            {
                Environment.Exit(0);
            }

            if (DateTime.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
            {
                return dateTime;
            }

            Console.WriteLine("Некоректне введення. Введіть дату в форматі (дд.мм.рррр).");
        }
    }

    public static string ReadNonEmptyString(string prompt, string errorPrompt = "")
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (input == null)
            {
                Environment.Exit(0);
            }

            // прибираємо пробіли по краях, щоб "Анна " і "Анна" були одним іменем
            input = input.Trim();

            if (input != "")
            {
                return input;
            }

            Console.WriteLine($"Некоректне введення. {errorPrompt}");
        }
    }

    public static void WaitForEnter()
    {
        Console.WriteLine();
        Console.Write("Натисніть Enter, щоб продовжити...");
        // ReadLine сам чекає саме на Enter, тому цикл не потрібен
        Console.ReadLine();
    }
}