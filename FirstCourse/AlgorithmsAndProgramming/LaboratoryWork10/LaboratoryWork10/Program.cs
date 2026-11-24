namespace LaboratoryWork10;

static class Program
{
    [STAThread]
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        
        Dictionary<string, string> phoneBook = new Dictionary<string, string>
        {
            ["Анна"] = "+380 93 094 10 12",
            ["Данило"] =  "+380 95 007 53 67",
            ["Іван"] = "+380 50 454 18 19"
        };

        Console.Write("---Консольна міні-програма---\n");
        while (true)
        {
            Console.WriteLine("Введіть:\n" +
                              "1 - перевірити приклад 1\n" +
                              "2 - перевірити приклад 2\n" +
                              "3 - перевірити приклад 3\n" +
                              "4 - перевірити приклад 4\n" +
                              "5 - перевірити приклад 5\n" +
                              "0 - вийти");
            string? choice = Console.ReadLine();

            switch (choice?.ToLower())
            {
                case "1":
                    Console.WriteLine(Example1("Введіть ціле число: "));
                    break;
                case "2": Example2(); break;
                case "3": Example3(); break;
                case "4": Example4(); break;
                case "5": Example5(phoneBook); break;
                case null:
                case "0": Environment.Exit(0); break;
                default: Console.WriteLine("Неправильний вибір."); break;
            }
        }
    }

    static int Example1(string prompt)
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

    static void Example2()
    {
        int limit = Example1("Введіть межу: ");
        int step = Example1("Введіть крок: ");
        
        if (step <= 0)
        {
            Console.WriteLine("Крок має бути більшим за 0.");
            return; 
        }

        Console.WriteLine($"{"x",8}{"y",10}");

        for (double x = 1; x <= limit; x += step)
        {
            double y = x * x;
            Console.WriteLine($"{x,8:F2}{y,10:F4}");
        }
    }

    static void Example3()
    {
        var now =  DateTime.Now;
#if WINDOWS
        System.Windows.Forms.MessageBox.Show(now.ToString("dd.MM.yyyy"));
        System.Windows.Forms.MessageBox.Show(now.ToString("HH:mm:ss"));
        System.Windows.Forms.MessageBox.Show(now.ToString("dd.MM.yyyy HH:mm"));
#else
        Console.WriteLine(now.ToString("dd.MM.yyyy"));
        Console.WriteLine(now.ToString("HH:mm:ss"));
        Console.WriteLine(now.ToString("dd.MM.yyyy HH:mm"));
#endif
    }

    static void Example4()
    {
        int temperature = Example1("Яка сьогодні температура? (ціле число): ");
        
        if  (temperature <= 0)
            Console.WriteLine("Холодно");
        else if (temperature < 15)
            Console.WriteLine("Прохолодно");
        else if  (temperature < 25)
            Console.WriteLine("Тепло");
        else
            Console.WriteLine("Спекотно");
    }

    static void Example5(Dictionary<string, string> phoneBook)
    {
        Console.WriteLine("Введіть:\n" +
                          "1 - показати всі контакти\n" +
                          "2 - знайти контакт\n" +
                          "3 - кількість контактів\n" +
                          "4 - додати контакт\n" +
                          "0 - вийти");
        string? choice =  Console.ReadLine();

        switch (choice)
        {
            case "1": 
                foreach (var contact in phoneBook)
                {
                    Console.WriteLine($"{contact.Key}: {contact.Value}");
                }

                break;
            case "2": 
                Console.WriteLine("Чий номер телефону ви шукаєте?");
                
                string? contactFind =  Console.ReadLine();
                if (contactFind != null && phoneBook.TryGetValue(contactFind, out string? number))
                    Console.WriteLine(number);
                else
                    Console.WriteLine("Не знайдено.");
                
                break;
            case "3":
                Console.WriteLine(phoneBook.Count);
                break;
            case "4":
                Console.WriteLine("Введіть ім'я контакту: ");
                string contactName = Console.ReadLine();
                Console.WriteLine("Введіть номер контакту " + contactName + ": ");
                string contactPhone = Console.ReadLine();
                phoneBook.Add(contactName, contactPhone);
                break;
            case "0": return;
        }
    }
}