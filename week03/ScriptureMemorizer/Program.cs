using System;

// The Program class runs the game.
// It shows the scripture, waits for the user, and hides words.

class Program
{
    static void Main(string[] args)
    {
        // Create the reference and the scripture.
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him and he shall direct thy paths.";
        Scripture scripture = new Scripture(reference, text);

        // Main loop: keep going until told to stop.
        while (true)
        {
            // Clear the screen and show the scripture.
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            // If all words are hidden, stop the program.
            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            // Ask the user to press Enter or type quit.
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine();

            // If the user types quit, stop the program.
            if (input.ToLower() == "quit")
            {
                break;
            }

            // Hide a few more words and loop again.
            scripture.HideRandomWords(3);
        }
    }
}