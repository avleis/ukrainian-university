using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введіть x: ");
        double x = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть y: ");
        double y = Convert.ToDouble(Console.ReadLine());

        double v;
        if (x < 0 && y <= 0)
            v = x * y;
        else if (x >= 0 && x < 10 && y > 0 && y <= 9)
            v = 1 / Math.Tan(x / y);
        else
            v = -100;

        Console.WriteLine($"v = {v}");
    }
}