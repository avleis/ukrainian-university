using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string[] months =
        [
            "Січень", "Лютий", "Березень", "Квітень", "Травень", "Червень",
            "Липень", "Серпень", "Вересень", "Жовтень", "Листопад", "Грудень"
        ];
        double[] T = new double[12];

        for (int i = 0; i <= 11; i++)
        {
            Console.Write($"Введіть температуру за місяць \"{months[i]}\", °C: ");
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

        Console.WriteLine(negMax == -1000 ? "Від'ємних температур немає." : $"Найвища від'ємна температура: {negMax} °C");
        Console.WriteLine(posMin == 1000 ? "Додатних температур немає." : $"Найнижча додатна температура: {posMin} °C");
    }
}