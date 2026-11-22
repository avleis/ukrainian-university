using System;

class Program
{
    static double[,] InputMatrix(int n, string name)
    {
        double[,] m = new double[n, n];
        Console.WriteLine($"Введіть матрицю {name}({n},{n}):");
        Console.WriteLine("кожен рядок - числа через пропуск");
        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            string[] parts = line.Split(' ',
                StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < n; j++)
            {
                m[i, j] = Convert.ToDouble(parts[j]);
            }
        }
        return m;
    }

    static void PrintMatrix(double[,] m, string name)
    {
        int n = m.GetLength(0);
        Console.WriteLine($"Матриця {name}({n},{n}):");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{m[i, j],8:F2}");
            }
            Console.WriteLine();
        }
    }

    static double MaxDiagonal(double[,] m)
    {
        int n = m.GetLength(0);
        double max = m[0, 0];
        for (int i = 1; i <= n - 1; i++)
        {
            if (m[i, i] > max)
            {
                max = m[i, i];
            }
        }
        return max;
    }

    static double MinDiagonal(double[,] m)
    {
        int n = m.GetLength(0);
        double min = m[0, 0];
        for (int i = 1; i <= n - 1; i++)
        {
            if (m[i, i] < min)
            {
                min = m[i, i];
            }
        }
        return min;
    }

    static void Report(double[,] m, string name)
    {
        PrintMatrix(m, name);
        double max = MaxDiagonal(m);
        double min = MinDiagonal(m);
        Console.WriteLine($"Максимум діагоналі {name}: {max}");
        Console.WriteLine($"Мінімум діагоналі {name}: {min}");
        Console.WriteLine();
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        double[,] A = InputMatrix(3, "A");
        double[,] Y = InputMatrix(5, "Y");
        double[,] C = InputMatrix(4, "C");

        Console.WriteLine();
        Report(A, "A");
        Report(Y, "Y");
        Report(C, "C");
    }
}