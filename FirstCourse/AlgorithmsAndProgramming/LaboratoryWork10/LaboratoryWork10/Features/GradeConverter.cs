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
        return score switch
        {
            > 89 => Grades[0].Ects,
            > 81 => Grades[1].Ects,
            > 73 => Grades[2].Ects,
            > 63 => Grades[3].Ects,
            > 59 => Grades[4].Ects,
            _ => Grades[5].Ects
        };
    }
    
    string GetNationals(int score)
    {
        return score switch
        {
            > 89 => Grades[0].National,
            > 81 => Grades[1].National,
            > 73 => Grades[2].National,
            > 63 => Grades[3].National,
            > 59 => Grades[4].National,
            _ => Grades[5].National
        };
    }

    void Convert()
    {
        int score = ConsoleInput.ReadInt("Який бал треба перевести? ");
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
