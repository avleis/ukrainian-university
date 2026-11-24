namespace LaboratoryWork10;

static class Program
{
    static readonly Menu MainMenu = new([
        "таблиця значень y = x²",
        "поточна дата і час",
        "оцінка погоди",
        "телефонна книга"
    ]);
    
    [STAThread]
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        
        PhoneBook phoneBook = new();

        Console.WriteLine("--- Консольна програма-помічник ---");
        while (true)
        {
            MainMenu.ShowMenu();
            int choice = ConsoleInput.ReadInt("Оберіть пункт меню: ");

            switch (choice)
            {
                case 1: Example2(); break;
                case 2: Example3(); break;
                case 3: Example4(); break;
                case 4: phoneBook.RunMenu(); break;
                case 0: Environment.Exit(0); break;
                default: Console.WriteLine("Неправильний вибір."); break;
            }
        }
    }

    static void Example2()
    {
        int limit = ConsoleInput.ReadInt("Введіть межу: ");
        int step = ConsoleInput.ReadInt("Введіть крок: ");
        
        if (step <= 0)
        {
            Console.WriteLine("Крок має бути більшим за 0.");
            return; 
        }

        Console.WriteLine($"{"x",8}{"y",10}");

        for (double x = 1; x <= limit; x += step)
        {
            double y = x * x;
            Console.WriteLine($"{x,8:F2}{y,10:F4}");
        }
    }

    static void Example3()
    {
        var now =  DateTime.Now;
#if WINDOWS
        System.Windows.Forms.MessageBox.Show(now.ToString("dd.MM.yyyy"));
        System.Windows.Forms.MessageBox.Show(now.ToString("HH:mm:ss"));
        System.Windows.Forms.MessageBox.Show(now.ToString("dd.MM.yyyy HH:mm"));
#else
        Console.WriteLine(now.ToString("dd.MM.yyyy"));
        Console.WriteLine(now.ToString("HH:mm:ss"));
        Console.WriteLine(now.ToString("dd.MM.yyyy HH:mm"));
#endif
    }

    static void Example4()
    {
        int temperature = ConsoleInput.ReadInt("Яка сьогодні температура? (ціле число): ");
        
        if  (temperature <= 0)
        {
            Console.WriteLine("Холодно");
        }
        else if (temperature < 15)
        {
            Console.WriteLine("Прохолодно");
        }
        else if  (temperature < 25)
        {
            Console.WriteLine("Тепло");
        }
        else
        {
            Console.WriteLine("Спекотно");
        }
    }
}