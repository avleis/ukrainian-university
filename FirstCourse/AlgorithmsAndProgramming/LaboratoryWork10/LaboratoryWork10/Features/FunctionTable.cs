using LaboratoryWork10.Common;

namespace LaboratoryWork10.Features;

public class FunctionTable
{
    static readonly string[] FunctionNames = ["x²", "x³", "√x", "sin x", "1/x"];

    string function = "x²";
    double start = 0;
    double limit = 5;
    double step = 0.5;

    static readonly ConsoleMenu FunctionTableMenu = new("─── Таблиця функцій ───", [
        "обрати функцію",
        "задати діапазон",
        "показати таблицю"
    ], "назад");

    static readonly ConsoleMenu FunctionListMenu = new("─── Вибір функції ───", FunctionNames, "назад");

    void ChooseFunction()
    {
        
        int choice = FunctionListMenu.Choose("Оберіть функцію: ");
        
        if (choice != 0)
        {
            function = FunctionNames[choice - 1];
        }
    }

    double Calculate(double x)
    {
        switch (function)
        {
            case "x²": return x * x;
            case "x³": return x * x * x;
            case "√x": return Math.Sqrt(x);
            case "sin x": return Math.Sin(x);
            case "1/x": return 1 / x;
        }

        // сюди потрапимо, лише якщо назву додали в масив, а формулу забули; NaN буде видно в таблиці
        return double.NaN;
    }

    bool IsDefined(double x)
    {
        if (x == 0 && function == "1/x")
        {
            return false;
        }
        else if (x < 0 && function == "√x")
        {
            return false;
        }

        return true;
    }

    void SetRange()
    {
        start = ConsoleInput.ReadDouble("Введіть початок: ");

        while (true)
        {
            double inputLimit = ConsoleInput.ReadDouble("Введіть межу: ");

            if (inputLimit > start)
            {
                limit = inputLimit;
                break;
            }

            Console.WriteLine("Помилка: межа має бути більшою за початок.");
        }

        while (true)
        {
            double inputStep = ConsoleInput.ReadDouble("Введіть крок: ");

            if (inputStep > 0)
            {
                step = inputStep;
                break;
            }

            Console.WriteLine("Помилка: крок має бути більшим за нуль.");
        }
    }

    void ShowTable()
    {
        Console.WriteLine($"Функція: {function}, діапазон: від {start} до {limit}, крок {step}");

        const int xWidth = 8;
        const int yWidth = 10;

        Console.WriteLine($"{"x",xWidth} │{function,yWidth}");
        Console.WriteLine(new string('─', xWidth + 1) + "┼" + new string('─', yWidth));

        int n = (int)Math.Floor((limit - start) / step + 1e-9);

        for (int i = 0; i <= n; i++)
        {
            double x = start + i * step;

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
