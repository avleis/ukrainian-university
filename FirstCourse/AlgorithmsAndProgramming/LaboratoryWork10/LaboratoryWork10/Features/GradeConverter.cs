using LaboratoryWork10.Common;

namespace LaboratoryWork10.Features;

public class GradeConverter
{
    static readonly Menu GradeConverterMenu = new("--- Конвертор оцінок ---", [
        "перевести бал в оцінку",
        "показати шкалу оцінювання"
    ], "назад");

    void Convert()
    {
        
    }

    void ShowScale()
    {
        
    }
    
    public void RunMenu()
    {
        while (true)
        {
            int choice = GradeConverterMenu.Choose();
            
            switch (choice)
            {
                case 1: Convert(); break;
                case 2: ShowScale(); break;
                case 0: return;
            }

            ConsoleInput.WaitForEnter();
        }
    }
}