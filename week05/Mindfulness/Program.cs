using System;

// =====================================================================
// W05 Project: Mindfulness Program
//
// Core requirements implemented:
// - Menu system to choose an activity.
// - Common starting message (name, description, duration prompt, pause).
// - Common ending message (good job, activity name, duration, pause).
// - Animations: a spinner and a countdown are shown during every pause.
// - Breathing, Reflecting, and Listing activities.
// - Inheritance: a base class "Activity" holds the shared data and
//   behavior, and each activity has its own child class. This avoids
//   duplicating the starting/ending messages and the animations.
// - Encapsulation and abstraction: every class uses private member
//   variables and keeps related data and methods together.
//
// Exceeding requirements (creativity):
// - In the Reflecting Activity, random questions do NOT repeat until all
//   of them have been used at least once in the session. When the list
//   runs out, it is refilled (see ReflectingActivity.GetRandomQuestion).
// =====================================================================

class Program
{
    static void Main(string[] args)
    {
        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("Please choose one of the following options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflecting Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Press enter to try again.");
                Console.ReadLine();
            }
        }
    }
}