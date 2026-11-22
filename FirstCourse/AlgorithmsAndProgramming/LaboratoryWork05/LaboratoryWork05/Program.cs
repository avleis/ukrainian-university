using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string[] months =
        [
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        ];
        double[] T = new double[12];

        for (int i = 0; i <= 11; i++)
        {
            Console.Write($"Enter the temperature for \"{months[i]}\", °C: ");
            T[i] = Convert.ToDouble(Console.ReadLine());
        }

        double negMax = -1000;   
        double posMin = 1000;    

        for (int i = 0; i <= 11; i++)
        {
            if (T[i] < 0 && T[i] > negMax)
            {
                negMax = T[i];
            }
            else if (T[i] > 0 && T[i] < posMin)
            {
                posMin = T[i];
            }
        }

        Console.WriteLine(negMax == -1000 ? "There are no negative temperatures." : $"The highest negative temperature: {negMax} °C");
        Console.WriteLine(posMin == 1000 ? "There are no positive temperatures." : $"The lowest positive temperature: {posMin} °C");
    }
}