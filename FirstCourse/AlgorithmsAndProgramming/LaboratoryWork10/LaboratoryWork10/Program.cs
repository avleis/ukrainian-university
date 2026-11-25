using LaboratoryWork10.Common;
using LaboratoryWork10.Features;

namespace LaboratoryWork10;

static class Program
{
    static readonly ConsoleMenu MainMenu = new("─── Консольна програма-помічник ───", [
        "таблиця функцій",
        "дата і час (працює через MessageBox)",
        "конвертер оцінок",
        "телефонна книга"
    ]);
    
    [STAThread]
    static void Main()
    {
        // налаштування кодування UTF-8 для роботи з кирилицею в консолі
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        
        FunctionTable functionTable = new();
        DateTool dateTool = new();
        GradeConverter gradeConvertor = new();
        PhoneBook phoneBook = new();

        while (true)
        {
            int choice = MainMenu.Choose();

            switch (choice)
            {
                case 1: functionTable.RunMenu(); continue;
                case 2: dateTool.RunMenu(); continue;
                case 3: gradeConvertor.RunMenu(); continue;
                case 4: phoneBook.RunMenu(); continue;
                case 0: Environment.Exit(0); break;
            }
            
            ConsoleInput.WaitForEnter();
        }
    }
}