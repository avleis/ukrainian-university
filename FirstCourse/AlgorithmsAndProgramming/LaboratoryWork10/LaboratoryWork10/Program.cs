using LaboratoryWork10.Common;
using LaboratoryWork10.Features;

namespace LaboratoryWork10;

static class Program
{
    static readonly Menu MainMenu = new("--- Консольна програма-помічник ---", [
        "таблиця функцій",
        "дата і час",
        "конвертер оцінок",
        "телефонна книга"
    ]);
    
    [STAThread]
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        
        PhoneBook phoneBook = new();
        FunctionTable functionTable = new();

        while (true)
        {
            int choice = MainMenu.Choose();

            switch (choice)
            {
                // після підменю пауза не потрібна: continue одразу повертає до головного меню
                case 1: functionTable.RunMenu(); continue;
                case 2: ShowDateTime(); break;
                case 3: RateWeather(); break;
                case 4: phoneBook.RunMenu(); continue;
                case 0: Environment.Exit(0); break;
            }
            
            ConsoleInput.WaitForEnter();
        }
    }

    static void ShowDateTime()
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

    static void RateWeather()
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