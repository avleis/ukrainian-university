using LaboratoryWork10.Common;

namespace LaboratoryWork10.Features;

public class DateTool
{
    static readonly Menu DateToolMenu = new("─── Дата і час ───", [
        "поточна дата і час",
        "скільки днів до кінця семестру",
        "калькулятор віку"
    ], "назад");
    
    static readonly DateTime SemesterEnd = new(2027, 06, 30);
    
    public void RunMenu()
    {
        while (true)
        {
            int choice = DateToolMenu.Choose();
            
            switch (choice)
            {
                case 1: ShowCurrentDateTime(); break;
                case 2: DaysUntilSemesterEnd(); break;
                case 3: AgeCalculator(); break;
                case 0: return;
            }

            ConsoleInput.WaitForEnter();
        }
    }

    static void Notify(string title, string text)
    {
#if WINDOWS
        System.Windows.Forms.MessageBox.Show(text, title, MessageBoxButtons.OK);
#else
        Console.WriteLine(title);
        Console.WriteLine(text);
#endif
    }
    
    void ShowCurrentDateTime()
    {
        Notify("Сьогоднішня дата та час", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
    }

    void DaysUntilSemesterEnd()
    {
        int days = (SemesterEnd - DateTime.Now).Days;
        
        if (days > 0) Notify("Дні до кінця семестру", $"До кінця семестру залишилось {days} днів.");
        else if (days == 0) Notify("Дні до кінця семестру", "Семестр закінчується сьогодні.");
        else Notify("Дні до кінця семестру", "Семестр уже закінчився.");
    }

    void AgeCalculator()
    {
        DateTime today = DateTime.Today;
        DateTime birthDate = ConsoleInput.ReadDate("Введіть дату народження (дд.мм.рррр): ");

        if (birthDate > today)
        {
            Notify("Помилка", "Дата народження не може бути в майбутньому.");
            return;
        }

        DateTime thisYearBirthday = new DateTime(today.Year, birthDate.Month, birthDate.Day);

        int age = today.Year - birthDate.Year;

        if (thisYearBirthday > today) age--;

        DateTime nextBirthday = thisYearBirthday;

        if (nextBirthday < today) nextBirthday = nextBirthday.AddYears(1);

        int daysLeft = (nextBirthday - today).Days;

        string text = $"Вік: {age}\n";

        if (daysLeft == 0) text += "З днем народження!";
        else text += $"До дня народження залишилось днів: {daysLeft}.";

        Notify("Калькулятор віку", text);
    }
}