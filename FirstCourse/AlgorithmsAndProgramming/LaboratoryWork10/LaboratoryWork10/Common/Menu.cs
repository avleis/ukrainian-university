namespace LaboratoryWork10.Common;

public class Menu
{
    public string[] Options { get; }
    public string ExitOption { get; }
    public string Title { get; }

    public Menu(string[] options, string exitOption = "вийти", string title = "")
    {
        Options = options;
        ExitOption = exitOption;
        Title = title;
    }

    public void ShowMenu()
    {
        if (Title != "")
        {
            Console.WriteLine(Title);
        }

        Console.WriteLine("--------------------");
        for (var i = 0; i < Options.Length; i++)
        {
            Console.WriteLine($"{i + 1} - {Options[i]}");
        }
        Console.WriteLine($"0 - {ExitOption}");
        Console.WriteLine("--------------------");
    }

    // очищає екран, показує меню і повертає номер існуючого пункту (0 — вихід або назад)
    public int Choose(string prompt = "Оберіть пункт меню: ")
    {
        Console.Clear();
        ShowMenu();

        while (true)
        {
            int choice = ConsoleInput.ReadInt(prompt);

            if (choice >= 0 && choice <= Options.Length)
            {
                return choice;
            }

            // екран не очищаємо, щоб повідомлення залишилось видно
            Console.WriteLine("Неправильний вибір.");
        }
    }
}
