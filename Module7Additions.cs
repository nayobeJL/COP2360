/*
 * COP2360 – Module 7 Group Project
 * Dictionary Management System
 * 
 * Role A – Justin Robinson (Lead / Repo Owner)
 * Role B – Robert Weinberger (Menu Developer)
 * Role C – Nayobe Jean-Louis (CRUD Developer)
 * Role D – Leopoldo Ramos (Extras Developer)
 * Role E – Donovan Zangwill (Display & Documentation)
 * 
 * Purpose:
 * Serves as the main entry point for the program.
 * Initializes the project and confirms that the repository and
 * structure are working before the menu and operations are implemented.
 */

using System;
using System.Collections.Generic;

namespace Module7DictionaryProject
{
    public class Operations
    {
        public Dictionary<string, List<string>> myDictionary { get; } = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        public void AddEntry()
        {
            Console.Clear();
            Console.WriteLine("=== Add New Entry ===");

            Console.Write("Enter word: ");
            string key = Console.ReadLine()?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(key))
            {
                Console.WriteLine("Error: Word cannot be empty.");
                return;
            }

            if (myDictionary.ContainsKey(key))
            {
                Console.WriteLine("Error: This word already exists.");
                return;
            }

            Console.Write("Enter definition: ");
            string definition = Console.ReadLine()?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(definition))
            {
                Console.WriteLine("Error: Definition cannot be empty.");
                return;
            }

            myDictionary[key] = new List<string> { definition };
            Console.WriteLine($"Added '{key}' successfully.");
        }

        public void SearchEntry() { }
        public void UpdateEntry() { }
        public void DeleteEntry() { }
        public void ViewAllEntries() { }

        public void ExtrasMenu()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("=== EXTRAS MENU ===");
                Console.WriteLine("1. Populate Dictionary (Preset Data)");
                Console.WriteLine("2. Remove All Entries");
                Console.WriteLine("3. Back to Main Menu");
                Console.Write("Enter your choice (1-3): ");

                string choice = Console.ReadLine()?.Trim() ?? string.Empty;

                switch (choice)
                {
                    case "1":
                        PopulateDictionary();
                        break;
                    case "2":
                        ClearDictionary();
                        break;
                    case "3":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }

                if (!back)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey(true);
                }
            }
        }
private void PopulateDictionary()
{
    Console.Clear();
    Console.WriteLine("=== Populating Dictionary with Turtle Facts ===");

    var sampleData = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
    {
        { "Turtle", new List<string> 
            { "A reptile with a hard shell that protects it from predators.",
              "Turtles live in a variety of environments including oceans, rivers, and forests." } 
        },
        { "Shell", new List<string> 
            { "The protective outer covering of a turtle body.",
              "It consists of two parts: the upper carapace and the lower plastron." } 
        },
        { "Habitat", new List<string> 
            { "Turtles can live in both aquatic and terrestrial environments depending on the species." } 
        },
        { "Diet", new List<string> 
            { "Turtles eat plants, insects, or small fish, depending on whether they are herbivores or carnivores." } 
        },
        { "Lifespan", new List<string> 
            { "Turtles are known for their longevity, with some living over 100 years." } 
        }
    };

    int added = 0, skipped = 0;

    foreach (var (word, definitions) in sampleData)
    {
        if (string.IsNullOrWhiteSpace(word) || myDictionary.ContainsKey(word))
        {
            skipped++;
            continue;
        }

        myDictionary[word] = definitions;
        added++;
    }

    Console.WriteLine($"\nPopulation complete: {added} added, {skipped} skipped.");
}

        private void ClearDictionary()
        {
            Console.Clear();
            Console.WriteLine("=== Clear Dictionary ===");
            Console.Write("Are you sure you want to remove all entries? (Y/N): ");
            string confirm = Console.ReadLine()?.Trim().ToUpper();

            if (confirm == "Y")
            {
                myDictionary.Clear();
                Console.WriteLine("All entries removed successfully.");
            }
            else
            {
                Console.WriteLine("Operation canceled.");
            }
        }
    }

    internal class Program
    {
        private static Operations manager = new Operations();

        static void Main(string[] args)
        {
            Console.Title = "COP2360 Module 7 – Dictionary Management System";
            Console.WriteLine("=== Module 7 Dictionary Project ===");
            Console.WriteLine("Repository and structure setup complete.");
            Console.WriteLine("Project initialized successfully.");
            Console.WriteLine("\nNext: Role B (Robert Weinberger) will implement the menu and switch statement.");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
            Console.Title = "Dictionary Management System";
            bool running = true;
            
            while (running)
            {
                DisplayMenu();
                running = HandleMenuChoice();
                
                if (running)
                {
                    Console.WriteLine("\nPress any key to return to Main Menu...");
                    Console.ReadKey(true);
                }
            }

            Console.WriteLine("\nProgram Exited.");
        }

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("DICTIONARY MENU");
            Console.WriteLine("=========================");
            Console.WriteLine("1. Add New Word");
            Console.WriteLine("2. Search for Word");
            Console.WriteLine("3. Update Entry");
            Console.WriteLine("4. Delete Entry");
            Console.WriteLine("5. View All Entries");
            Console.WriteLine("6. Extras Menu");
            Console.WriteLine("7. Exit Program");
            Console.WriteLine("-------------------------");
            Console.Write("Enter choice (1-7): ");
        }

        private static bool HandleMenuChoice()
        {
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        manager.AddEntry();
                        break;
                    case 2:
                        manager.SearchEntry();
                        break;
                    case 3:
                        manager.UpdateEntry();
                        break;
                    case 4:
                        manager.DeleteEntry();
                        break;
                    case 5:
                        manager.ViewAllEntries();
                        break;
                    case 6:
                        manager.ExtrasMenu();
                        break;
                    case 7:
                        return false;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Enter a number.");
            }
            return true;
        }
    }
}
