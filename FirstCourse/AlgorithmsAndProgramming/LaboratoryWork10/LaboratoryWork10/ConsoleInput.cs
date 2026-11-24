namespace LaboratoryWork10;

public static class ConsoleInput
{
    public static int ReadInt(string prompt = "")
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                return number; 
            }

            Console.WriteLine("Некоректне введення. Введіть ціле число.");
        }
    }

    public static string ReadNonEmptyString(string prompt, string errorPrompt = "")
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }
                    
            Console.WriteLine($"Некоректне введення. {errorPrompt}");
        }
    }
    
    public static string InputPhoneNumber(string contactName)
    {
        while (true)
        {
            Console.Write("Введіть номер телефону для контакту " + contactName + " (без пробілів): ");
            string? input = Console.ReadLine();

            if (input != null && IsValidPhoneNumber(input)) return input;
            
            Console.WriteLine("Некоректне введення. Введіть номер телефону у форматі +380931048101.");
        }
    }
    
    static bool IsValidPhoneNumber(string phoneNumber)
    {
        if (phoneNumber.Length != 13 || !phoneNumber.StartsWith("+380"))
        {
            return false;
        }

        for (var i = 1; i < phoneNumber.Length; i++)
            if (!char.IsDigit(phoneNumber[i]))
                return false;
        
        return true;
    }
}