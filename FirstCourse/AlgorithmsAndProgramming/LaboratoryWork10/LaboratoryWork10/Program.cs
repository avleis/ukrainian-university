namespace LaboratoryWork10;

static class Program
{
    [STAThread]
    static void Main()
    {
        Console.Write("---This is a console mini-program---\n");
        while (true)
        {
            Console.WriteLine("Enter:\n" +
                              "1 - to test Example 1\n" +
                              "2 - to test Example 2\n" +
                              "3 - to test Example 3\n" +
                              "4 - to test Example 4\n" +
                              "5 - to test Example 5\n" +
                              "exit - to Exit");
            string? choice = Console.ReadLine();

            switch (choice?.ToLower())
            {
                case "1":
                    Console.WriteLine(Example1("Enter integer: "));
                    break;
                case "2": Example2(); break;
                case "3": Example3(); break;
                case "4": Example4(); break;
                case "5": Example5(); break;
                case null:
                case "exit": Environment.Exit(0); break;
                default: Console.WriteLine("Invalid choice."); break;
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

            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }

    static void Example2()
    {
        int limit = Example1("Enter limit: ");
        int step = Example1("Enter step: ");
        
        if (step <= 0)
        {
            Console.WriteLine("Step must be greater than 0.");
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
        int temperature = Example1("What's the temperature today? (int): ");
        
        if  (temperature <= 0)
            Console.WriteLine("It's cold");
        else if (temperature < 15)
            Console.WriteLine("It's chilly");
        else if  (temperature < 25)
            Console.WriteLine("It's warm");
        else
            Console.WriteLine("It's hot");
    }

    static void Example5()
    {
        Dictionary<string, string> phoneBook = new Dictionary<string, string>
        {
            ["Anna"] = "+380 93 094 10 12",
            ["Daniel"] =  "+380 95 007 53 67"
        };
        phoneBook.Add("John", "+380 50 454 18 19");
        
        Console.WriteLine("Enter:\n" +
                          "1 - show all contacts\n" +
                          "2 - find contact\n" +
                          "3 - count contacts\n" +
                          "exit - to Exit");
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
                Console.WriteLine("Whose phone number are you looking for?");
                
                string? contactFind =  Console.ReadLine();
                if (contactFind != null && phoneBook.TryGetValue(contactFind, out string? number))
                    Console.WriteLine(number);
                else
                    Console.WriteLine("Not found.");
                
                break;
            case "3":
                Console.WriteLine(phoneBook.Count);
                break;
            case "exit": return;
        }
    }
}