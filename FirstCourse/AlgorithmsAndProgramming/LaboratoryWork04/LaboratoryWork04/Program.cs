using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        const double a = 10, b = 20;
        int m = 20;

        double h = (b - a) / m;

        Console.WriteLine("    x          f(x)");
        for (int i = 0; i <= m; i++)
        {
            double x = a + i * h;
            double y = Math.Atan(x) + 1;
            Console.WriteLine($"{x,8:F2}  {y,10:F4}");
        }
    }
}