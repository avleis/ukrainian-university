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
        GradeConverter gradeConverter = new();
        PhoneBook phoneBook = new();
        
        while (true)
        {
            int choice = MainMenu.Choose();

            switch (choice)
            {
                case 1: functionTable.RunMenu(); break;
                case 2: dateTool.RunMenu(); break;
                case 3: gradeConverter.RunMenu(); break;
                case 4: phoneBook.RunMenu(); break;
                case 0: return;
            }
        }
    }
}