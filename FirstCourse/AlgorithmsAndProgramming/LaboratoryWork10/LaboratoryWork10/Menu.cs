namespace LaboratoryWork10;

public class Menu
{
    public string[] MenuOption { get; set; }
    public string ExitOption { get; set; }
    
    public Menu(string[] menuOption, string exitOption = "вийти")
    {
        MenuOption = menuOption;
        ExitOption = exitOption;
    }

    public void ShowMenu()
    {
        Console.WriteLine("--------------------");
        for (var i = 0; i < MenuOption.Length; i++)
        {
            Console.WriteLine($"{i + 1} - {MenuOption[i]}");
        }
        Console.WriteLine($"0 - {ExitOption}");
        Console.WriteLine("--------------------");
    }
}