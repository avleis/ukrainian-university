using System;
using System.Globalization;
using System.IO;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        string inPath = "input.txt"; // сторони прямокутників
        string outPath = "output.txt"; // таблиця з результатами

        if (!File.Exists(inPath))
        {
            Console.WriteLine("Файл input.txt не знайдено.");
            return;
        }

        using (StreamReader reader = new StreamReader(inPath))
        using (StreamWriter writer = new StreamWriter(outPath))
        {
            writer.WriteLine("{0,10}{1,10}{2,12}{3,12}", "Сторона a", "Сторона b", "Периметр", "Площа");

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                double a = double.Parse(parts[0]);
                double b = double.Parse(parts[1]);

                double p = 2 * (a + b);   
                double s = a * b;     

                writer.WriteLine($"{a,10:F2}{b,10:F2}{p,12:F2}{s,12:F2}");
            }
        }

        Console.WriteLine("Результат записано в output.txt");
    }
}