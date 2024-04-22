using System;

class Program
{
    static int earthHealth = 100;
    static int currentDay = 1;
    static Random random = new Random();

    static void Main(string[] args)
    {
        ShowMenu();
    }

    static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
   ___ _ _                 _           ___ _                              __ _                 _       _   _             
  / __\ (_)_ __ ___   __ _| |_ ___    / __\ |__   __ _ _ __   __ _  ___  / _(_)_ __ ___  _   _| | __ _| |_(_) ___  _ __  
 / /  | | | '_ ` _ \ / _` | __/ _ \  / /  | '_ \ / _` | '_ \ / _` |/ _ \ \ \| | '_ ` _ \| | | | |/ _` | __| |/ _ \| '_ \ 
/ /___| | | | | | | | (_| | ||  __/ / /___| | | | (_| | | | | (_| |  __/ _\ \ | | | | | | |_| | | (_| | |_| | (_) | | | |
\____/|_|_|_| |_| |_|\__,_|\__\___| \____/|_| |_|\__,_|_| |_|\__, |\___| \__/_|_| |_| |_|\__,_|_|\__,_|\__|_|\___/|_| |_|
                                                             |___/                                                       
");
        Console.ResetColor(); // Reset color to default
        Console.WriteLine();
        Console.WriteLine("                                         ----------------------------");
        Console.WriteLine("                                         || 1. Start Game         ||");         
        Console.WriteLine("                                         || 2. Credits            ||");
        Console.WriteLine("                                         || 3. Exit               ||");
        Console.WriteLine("                                         ----------------------------");
        Console.Write("                                         Choose an option: ");

        int choice = int.Parse(Console.ReadLine());
        Console.WriteLine();

        switch (choice)
        {
            case 1:
                StartGame();
                break;
            case 2:
                ShowCredits();
                break;
            case 3:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please choose again.");
                ShowMenu();
                break;
        }
    }

    static void StartGame()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
   ___ _ _                 _           ___ _                              __ _                 _       _   _             
  / __\ (_)_ __ ___   __ _| |_ ___    / __\ |__   __ _ _ __   __ _  ___  / _(_)_ __ ___  _   _| | __ _| |_(_) ___  _ __  
 / /  | | | '_ ` _ \ / _` | __/ _ \  / /  | '_ \ / _` | '_ \ / _` |/ _ \ \ \| | '_ ` _ \| | | | |/ _` | __| |/ _ \| '_ \ 
/ /___| | | | | | | | (_| | ||  __/ / /___| | | | (_| | | | | (_| |  __/ _\ \ | | | | | | |_| | | (_| | |_| | (_) | | | |
\____/|_|_|_| |_| |_|\__,_|\__\___| \____/|_| |_|\__,_|_| |_|\__, |\___| \__/_|_| |_| |_|\__,_|_|\__,_|\__|_|\___/|_| |_|
                                                             |___/                                                       
");
        Console.ResetColor(); // Reset color to default
        Console.WriteLine();// Add an empty line for better readability

        while (earthHealth > 0 && earthHealth <= 100)
        {
            Console.WriteLine("                                         ----------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"                                         Day {currentDay}: {GetEarthHealthDescription()}");
            Console.ResetColor(); // Reset color to default

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"                                         Earth Health: {earthHealth}%");
            Console.ResetColor(); // Reset color to default
            Console.WriteLine("                                         ----------------------------");
            Console.WriteLine();// Add an empty line for better readability

            string scenario = GetRandomScenario();
            string[] options = GetOptionsForScenario(scenario);

            Console.WriteLine($"                                         Scenario: {scenario}");
            Console.WriteLine("                                         ----------------------------");
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"                                         Option {i + 1}: {options[i]}");
            }
            Console.WriteLine("                                         ----------------------------");

            Console.Write("                                         Choose an option (1-4): ");
            int choice = int.Parse(Console.ReadLine());

            string description = ProcessOption(scenario, choice);
            Console.ForegroundColor = ConsoleColor.Cyan; // Set color to cyan
            Console.WriteLine( );// Add an empty line for better readability
            Console.WriteLine(description);
            Console.ResetColor(); // Reset color to default

            currentDay++; // Move the day increment here

            Console.WriteLine("                                         ________________________________________");
            Console.WriteLine(); // Add an empty line for better readability
        }

        Console.WriteLine("                                         Game Over!");
    }

    static void ShowCredits()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
                                         _____              _ _ _       
                                        / ____|            | (_) |      
                                       | |     _ __ ___  __| |_| |_ ___ 
                                       | |    | '__/ _ \/ _` | | __/ __|
                                       | |____| | |  __/ (_| | | |_\__ \
                                        \_____|_|  \___|\__,_|_|\__|___/
                                  
                                  
");
        Console.ResetColor(); // Reset color to default
        Console.WriteLine("                                         ----------------------------");
        Console.WriteLine("                                         || Developed by Nicole F. ||");
        Console.WriteLine("                                         || Thank you for playing! ||");
        Console.WriteLine("                                         ----------------------------");
        Console.WriteLine(); // Add an empty line for better readability
        Console.WriteLine("                                         Press Enter to return to the main menu...");
        Console.ReadLine(); // Wait for user to press Enter
        Console.Clear(); // Clear the console before showing the menu again
        ShowMenu(); // After showing credits, go back to the main menu
    }

    static string GetEarthHealthDescription()
    {
        if (earthHealth >= 80)
        {
            return "Earth is in excellent health.";
        }
        else if (earthHealth >= 60)
        {
            return "Earth is in good health.";
        }
        else if (earthHealth >= 40)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return "Earth health is declining.";
            Console.ResetColor(); // Reset color to default
        }
        else if (earthHealth >= 20)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return "Earth is in critical condition.";
            Console.ResetColor(); // Reset color to default
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return "Earth is on the brink of collapse.";
            Console.ResetColor(); // Reset color to default
        }
    }

    static string GetRandomScenario()
    {
        string[] scenarios = {
            "Deforestation in the Amazon rainforest",
            "Melting polar ice caps",
            "Extreme weather events",
            "Rising sea levels"
            // Add more scenarios as needed
        };
        int index = random.Next(scenarios.Length);
        return scenarios[index];
    }

    static string[] GetOptionsForScenario(string scenario)
    {
        // You can define options for different scenarios here
        return new string[] { "Take action to address the issue", "Ignore the problem", "Delay action", "Blame another country" };
    }

    static string ProcessOption(string scenario, int choice)
    {
        int effect = 0;
        string description = "";

        string[] actions = {
            "Implemented reforestation programs",
            "Invested in renewable energy sources",
            "Supported international climate agreements",
            "Launched awareness campaigns"
            // Add more actions as needed
        };


        switch (choice)
        {
            case 1:
                // Take action to address the issue
                effect = random.Next(5, 11); // Randomly increase earthHealth
                description = $"                                         You {actions[random.Next(actions.Length)]} to address the issue. Earth's health improved.";
                break;
            case 2:
                // Ignore the problem
                effect = random.Next(-10, -4); // Randomly decrease earthHealth
                description = $"                                         You ignored the problem. Earth's health declined.";
                break;
            case 3:
                // Delay action
                effect = random.Next(-8, -2); // Randomly decrease earthHealth
                description = $"                                         You delayed action. Earth's health declined.";
                break;
            case 4:
                // Blame another country
                effect = random.Next(-7, -1); // Randomly decrease earthHealth
                description = $"                                         You blamed another country. Earth's health declined.";
                break;
            default:
                description = "                                         Invalid choice.";
                break;
        }

        earthHealth += effect;
        if (earthHealth < 0) // Ensure earthHealth is not negative
            earthHealth = 0;
        else if (earthHealth > 100) // Ensure earthHealth does not exceed 100%
            earthHealth = 100;

        return description;
    }

    static void PrintLargeText(string text)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Console.Write(" "); // Add extra space for larger appearance
        }
    }
}