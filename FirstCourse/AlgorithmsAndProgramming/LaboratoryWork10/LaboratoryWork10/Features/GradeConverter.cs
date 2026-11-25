using LaboratoryWork10.Common;

namespace LaboratoryWork10.Features;

public class GradeConverter
{
    static readonly Menu GradeConverterMenu = new("─── Конвертор оцінок ───", [
        "перевести бал в оцінку",
        "показати шкалу оцінювання"
    ], "назад");

    char GetEcts(int score)
    {
        if (score > 89) return 'A';
        else if (score > 81) return 'B';
        else if (score > 73) return 'C';
        else if (score > 63) return 'D';
        else if (score > 59) return 'E';
        else return 'F';
    }
    
    string GetNationals(int score)
    {
        if (score > 89) return "відмінно";
        else if (score > 81) return "добре";
        else if (score > 73) return "задовільно";
        else if (score > 63) return "задовільно";
        else if (score > 59) return "задовільно";
        else return "незадовільно";
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
