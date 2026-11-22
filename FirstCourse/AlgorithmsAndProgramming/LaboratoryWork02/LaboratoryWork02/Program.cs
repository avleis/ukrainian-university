using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введіть k1: ");
        double k1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть k2: ");
        double k2 = Convert.ToDouble(Console.ReadLine());

        double t = (k2 - k1) / (1 + k1 * k2);   
        double phi = Math.Atan(t);              
        double phiDeg = phi * 180 / Math.PI;

        Console.WriteLine($"tg(phi) = {t:F4}");
        Console.WriteLine($"phi = {phi:F4} рад = {phiDeg:F2} град");
    }
}