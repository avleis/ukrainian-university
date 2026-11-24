using LaboratoryWork10.Common;

namespace LaboratoryWork10.Features;

public class PhoneBook
{
    readonly Dictionary<string, string> phoneBook = new Dictionary<string, string>
    {
        ["Анна"] = "+380930941012",
        ["Данило"] =  "+380950075367",
        ["Іван"] = "+380504541819"
    };

    static readonly Menu PhoneBookMenu = new([
        "показати всі контакти",
        "знайти контакт",
        "додати контакт",
        "видалити контакт"
    ], "назад", "--- Телефонна книга ---");

    void ShowAll()
    {
        Console.WriteLine("--------------------");
        Console.WriteLine($"Усього контактів: {phoneBook.Count}");
        foreach (var contact in phoneBook)
        {
            Console.WriteLine($"{contact.Key}: {contact.Value}");
        }
        Console.WriteLine("--------------------");
    }

    void Find()
    {
        string contactName = ConsoleInput.ReadNonEmptyString("Чий номер телефону ви шукаєте? ", "Ім'я не може бути порожнім.");

        if (phoneBook.TryGetValue(contactName, out string? number))
        {
            Console.WriteLine($"Номер телефону контакту {contactName}: {number}");
        }
        else
        {
            Console.WriteLine("Контакт не знайдено.");
        }
    }

    void Add()
    {
        while (true)
        {
            string contactName = ConsoleInput.ReadNonEmptyString("Введіть ім'я контакту: ", "Ім'я не може бути порожнім.");

            if (phoneBook.ContainsKey(contactName))
            {
                Console.WriteLine("Введіть ім'я контакту, якого немає в телефонній книзі.");
            }
            else
            {
                string contactPhone = InputPhoneNumber(contactName);
                phoneBook.Add(contactName, contactPhone);
                break;
            }
        }
    }

    void Remove()
    {
        string contactName = ConsoleInput.ReadNonEmptyString("Введіть ім'я контакту, який треба видалити: ", "Ім'я не може бути порожнім.");

        if (phoneBook.Remove(contactName))
        {
            Console.WriteLine("Контакт видалено з телефонної книги.");
        }
        else
        {
            Console.WriteLine("Контакт не знайдено.");
        }
    }

    static string InputPhoneNumber(string contactName)
    {
        while (true)
        {
            Console.Write("Введіть номер телефону для контакту " + contactName + " (без пробілів): ");
            string? input = Console.ReadLine();

            if (input == null)
            {
                Environment.Exit(0);
            }

            if (IsValidPhoneNumber(input))
            {
                return input;
            }

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
        {
            if (!char.IsDigit(phoneNumber[i]))
            {
                return false;
            }
        }

        return true;
    }

    public void RunMenu()
    {
        while (true)
        {
            int choice = PhoneBookMenu.Choose();

            switch (choice)
            {
                case 1: ShowAll(); break;
                case 2: Find(); break;
                case 3: Add(); break;
                case 4: Remove(); break;
                case 0: return;
            }

            ConsoleInput.WaitForEnter();
        }
    }
}
