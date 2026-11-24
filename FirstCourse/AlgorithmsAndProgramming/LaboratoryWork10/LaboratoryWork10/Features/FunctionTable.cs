using LaboratoryWork10.Common;

namespace LaboratoryWork10.Features;

public class FunctionTable
{
    private int Function { get; set; }
    private double Start { get; set; }
    private double Limit { get; set; }
    private double Step { get; set; }
    
    public FunctionTable(int function = 1, double start = 0, double limit = 5, double step = 0.5)
    {
        Function = function;
        Start = start;
        Limit = limit;
        Step = step;
    }
    
    static Dictionary<string, int> functionList = new Dictionary<string, int>
    {
        ["x²"] = 1,
        ["x³"] = 2,
        ["√x"] = 3,
        ["sin x"] = 4,
        ["1/x"] = 5
    };
    
    static readonly Menu FunctionTableMenu = new([
        "обрати функцію",
        "задати діапазон",
        "показати таблицю"
    ], "назад");

    static readonly Menu FunctionListMenu = new(functionList.Keys.ToArray(), "назад");

    void ChooseFunction()
    {
        // Choose повертає тільки існуючий пункт, тому перевіряти номер ще раз не треба
        int choice = FunctionListMenu.Choose("Оберіть функцію: ");

        // 0 — назад, функцію не змінюємо
        if (choice != 0)
        {
            Function = choice;
        }
    }

    string? GetFunctionName()
    {
        foreach (var pair in functionList)
        {
            if (pair.Value == Function)
            {
                return pair.Key;
            }
        }

        return null;
    }
    
    double Calculate(double x)
    {
        switch (Function)
        {
            case 1: return Math.Pow(x, 2);
            case 2: return Math.Pow(x, 3);
            case 3: return Math.Sqrt(x);
            case 4: return Math.Sin(x);
            case 5: return Math.Pow(x, -1);
        }

        return 0;
    }

    bool IsDefined(double x)
    {
        if (x == 0 && Function == 5)
            return false;
        else if (x < 0 && Function == 3)
            return false;
        return true;
    }

    void SetRange()
    {
        Start = ConsoleInput.ReadDouble("Введіть початок: ");

        while (true)
        {
            double limit = ConsoleInput.ReadDouble("Введіть межу: ");

            if (limit > Start)
            {
                Limit = limit;
                break;
            }

            Console.WriteLine("Помилка: межа має бути більшою за початок.");
        }

        while (true)
        {
            double step = ConsoleInput.ReadDouble("Введіть крок: ");

            if (step > 0)
            {
                Step = step;
                break;
            }

            Console.WriteLine("Помилка: крок має бути більшим за нуль.");
        }
    }

    void ShowTable()
    {
        // ширина колонок; const, бо в {x,ширина} можна писати тільки константу
        const int xWidth = 8;
        const int yWidth = 10;

        Console.WriteLine($"{"x",xWidth} │{GetFunctionName(),yWidth}");
        Console.WriteLine(new string('─', xWidth + 1) + "┼" + new string('─', yWidth));

        int n = (int)Math.Round((Limit - Start) / Step);

        for (int i = 0; i <= n; i++)
        {
            double x = Start + i * Step;

            // через похибку double замість 0 може вийти, наприклад, -1e-16, тому таке число вважаємо нулем
            if (Math.Abs(x) < 1e-9)
            {
                x = 0;
            }

            if (IsDefined(x))
            {
                double y = Calculate(x);
                Console.WriteLine($"{x,xWidth:F2} │{y,yWidth:F4}");
            }
            else
            {
                Console.WriteLine($"{x,xWidth:F2} │{"-",yWidth}");
            }
        }
    }
    
    public void RunMenu()
    {
        while (true)
        {
            int choice = FunctionTableMenu.Choose();

            switch (choice)
            {
                case 1: ChooseFunction(); break;
                case 2: SetRange(); break;
                case 3: ShowTable(); break;
                case 0: return;
            }
            
            ConsoleInput.WaitForEnter();
        }
    }
}