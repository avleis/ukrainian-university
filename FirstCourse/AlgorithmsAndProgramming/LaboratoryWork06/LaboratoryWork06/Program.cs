using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        string[] S = new string[10];

        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Введіть рядок № {i + 1}: ");
            S[i] = Console.ReadLine();
        }

        string result = "";
        for (int i = 0; i <= 9; i++)
        {
            result = result + S[i];
        }

        Console.WriteLine("Результат об'єднання:");
        Console.WriteLine(result);
        Console.WriteLine($"Довжина рядка: {result.Length}");
    }
}