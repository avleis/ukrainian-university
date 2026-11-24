namespace LaboratoryWork10;

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
    ], "назад");
    
    void ShowAll()
    {
        Console.WriteLine("--------------------");
        Console.WriteLine($"- Усього контактів: {phoneBook.Count} -");
        foreach (var contact in phoneBook)
        {
            Console.WriteLine($"{contact.Key}: {contact.Value}");
        }
        Console.WriteLine("--------------------");
    }

    void Find()
    {
        Console.Write("Чий номер телефону ви шукаєте? ");
                
        string? contactFind =  Console.ReadLine();
        if (contactFind != null && phoneBook.TryGetValue(contactFind, out string? number))
        {
            Console.WriteLine(number);
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
                string contactPhone = ConsoleInput.InputPhoneNumber(contactName);
                phoneBook.Add(contactName, contactPhone);
                break;
            }
        }
    }

    void Remove()
    {
        Console.Write("Введіть ім'я контакту, який треба видалити: ");
                
        string? contactName =  Console.ReadLine();
        if (contactName != null && phoneBook.Remove(contactName))
        {
            Console.WriteLine("Контакт видалено з телефонної книги.");
        }
        else
        {
            Console.WriteLine("Контакт не знайдено.");
        }
    }

    public void RunMenu()
    {
        PhoneBookMenu.ShowMenu();
        int choice = ConsoleInput.ReadInt("Оберіть пункт меню: ");

        switch (choice)
        {
            case 1: ShowAll(); break;
            case 2: Find(); break;
            case 3: Add(); break;
            case 4: Remove(); break;
            case 0: return;
            default: Console.WriteLine("Неправильний вибір."); break;
        }
    }
}