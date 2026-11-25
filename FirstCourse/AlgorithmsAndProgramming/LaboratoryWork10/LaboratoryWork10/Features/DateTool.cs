using LaboratoryWork10.Common;

namespace LaboratoryWork10.Features;

public class DateTool
{
    static readonly Menu GradeConverterMenu = new("--- Дата і час ---", [
        "поточна дата і час",
        "скільки днів до кінця семестру",
        "калькулятор віку"
    ], "назад");
    
    static void ShowDateTime()
    {
        var now =  DateTime.Now;
#if WINDOWS
        System.Windows.Forms.MessageBox.Show(now.ToString("dd.MM.yyyy"));
#else
        Console.WriteLine(now.ToString("dd.MM.yyyy"));
#endif
    }
    
    public void RunMenu()
    {
        while (true)
        {
            int choice = GradeConverterMenu.Choose();
            
            switch (choice)
            {
                case 1: ShowDateTime(); break;
                case 0: return;
            }

            ConsoleInput.WaitForEnter();
        }
    }
}