using System;

// =============================================================
// Journal Program - W02 Project
//
// Exceeding requirements:
// - Expanded prompt list (more than 5 prompts).
// - User input validation in the menu (does not break with invalid input).
// - Messages when the journal is empty or the file does not exist.
// =============================================================

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!\n");

        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Write a new entrie
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\n{prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Entry newEntry = new Entry();
                    newEntry._date = DateTime.Now.ToShortDateString();
                    newEntry._promptText = prompt;
                    newEntry._entryText = response;

                    journal.AddEntry(newEntry);
                    Console.WriteLine();
                    break;

                case "2":
                    // Show all entries
                    Console.WriteLine();
                    journal.DisplayAll();
                    break;

                case "3":
                    // Load the file
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "4":
                    // Save the file
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "5":
                    // QUit
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose 1-5.\n");
                    break;
            }
        }
    }
}