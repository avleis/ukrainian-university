using LaboratoryWork10.Common;

namespace LaboratoryWork10.Features;

public class GradeConverter
{
    static readonly ConsoleMenu GradeConverterMenu = new("─── Конвертор оцінок ───", [
        "перевести бал в оцінку",
        "показати шкалу оцінювання"
    ], "назад");

    char GetEcts(int score)
    {
        return score switch
        {
            > 89 => 'A',
            > 81 => 'B',
            > 73 => 'C',
            > 63 => 'D',
            > 59 => 'E',
            _ => 'F'
        };
    }
    
    string GetNationals(int score)
    {
        return score switch
        {
            > 89 => "відмінно",
            > 81 => "добре",
            > 73 => "задовільно",
            > 63 => "задовільно",
            > 59 => "задовільно",
            _ => "незадовільно"
        };
    }

    void Convert()
    {
        int score = ConsoleInput.ReadInt("Який бал треба перевести? ");
        Console.WriteLine($"Бали: {score}, ECTS: {GetEcts(score)},  Національна: {GetNationals(score)}");
    }
    
    // самое тупое что я когда-то делал
    void ShowScale()
    {
        Console.WriteLine($"{"Бали",-10} │ {"ECTS",-10} │ {"Національна",7}");
        Console.Write(new string('─', 11));
        Console.Write("┼");
        Console.Write(new string('─', 12));
        Console.Write("┼");
        Console.WriteLine(new string('─', 14));
        Console.WriteLine($"{"90–100",-10} │ {"A",-10} │ {"відмінно",-10}");
        Console.WriteLine($"{"82–89",-10} │ {"B",-10} │ {"добре",-10}");
        Console.WriteLine($"{"74–81",-10} │ {"C",-10} │ {"добре",-10}");
        Console.WriteLine($"{"64–73",-10} │ {"D",-10} │ {"задовільно",-10}");
        Console.WriteLine($"{"60–63",-10} │ {"E",-10} │ {"задовільно",-10}");
        Console.WriteLine($"{"0–59",-10} │ {"F",-10} │ {"незадовільно",-10}");
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
