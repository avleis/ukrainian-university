using LaboratoryWork10.Common;

namespace LaboratoryWork10.Features;

public class GradeConverter
{
    static readonly ConsoleMenu GradeConverterMenu = new("─── Конвертор оцінок ───", [
        "перевести бал в оцінку",
        "показати шкалу оцінювання"
    ], "назад");

    static readonly (string Points, char Ects, string National)[] Grades =
    [
        ("90–100", 'A', "відмінно"),
        ("82–89",  'B', "добре"),
        ("74–81",  'C', "добре"),
        ("64–73",  'D', "задовільно"),
        ("60–63",  'E', "задовільно"),
        ("0–59",   'F', "незадовільно")
    ];

    char GetEcts(int score)
    {
        if (score > 89) return Grades[0].Ects;
        else if (score > 81) return Grades[1].Ects;
        else if (score > 73) return Grades[2].Ects;
        else if (score > 63) return Grades[3].Ects;
        else if (score > 59) return Grades[4].Ects;
        else return Grades[5].Ects;
    }
    
    string GetNationals(int score)
    {
        if (score > 89) return Grades[0].National;
        else if (score > 81) return Grades[1].National;
        else if (score > 73) return Grades[2].National;
        else if (score > 63) return Grades[3].National;
        else if (score > 59) return Grades[4].National;
        else return Grades[5].National;
    }

    void Convert()
    {
        int score = ConsoleInput.ReadIntInRange("Який бал треба перевести? ", 0, 100);
        Console.WriteLine($"Бали: {score}, ECTS: {GetEcts(score)},  Національна: {GetNationals(score)}");
    }

    static string FormatRow(string score, char ects, string national)
    {
        return $" {score,-10} │ {ects,-10} │ {national,-12}";
    }
    
    void ShowScale()
    {
        Console.WriteLine($" {"Бали",-10} │ {"ECTS",-10} │ {"Національна",-12}");
        Console.WriteLine($"{new string('─', 12)}┼{new string('─', 12)}┼{new string('─', 14)}");

        foreach (var (points, ects, national) in Grades)
        {
            Console.WriteLine(FormatRow(points, ects, national));
        }
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
