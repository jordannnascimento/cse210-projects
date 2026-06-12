using System;
using System.Collections.Generic;
using System.IO;

// Eternal Quest Program (beginner version).
// This program meets the core requirements: simple, eternal, and
// checklist goals; create goals; record events; list goals; show
// the score; and save/load goals.
class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine($"\nYou have {score} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("\nThe types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("How many points is this goal worth? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be done? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for finishing it? ");
            int bonus = int.Parse(Console.ReadLine());
            goals.Add(new ChecklistGoal(name, description, points, bonus, target));
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    static void ListGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("\nYou don't have any goals yet.");
            return;
        }

        Console.WriteLine("\nYour goals are:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }
    }

    static void RecordEvent()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("\nYou don't have any goals yet.");
            return;
        }

        ListGoals();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            int earned = goals[index].RecordEvent();
            score += earned;
            Console.WriteLine($"You earned {earned} points! You now have {score} points.");
        }
        else
        {
            Console.WriteLine("That goal does not exist.");
        }
    }

    static void SaveGoals()
    {
        Console.Write("What is the filename to save to? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(score); // first line is the score
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved!");
    }

    static void LoadGoals()
    {
        Console.Write("What is the filename to load from? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("That file does not exist.");
            return;
        }

        goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        score = int.Parse(lines[0]); // first line is the score

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string[] data = parts[1].Split(",");

            if (type == "SimpleGoal")
            {
                // name, description, points, completed
                goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
            }
            else if (type == "EternalGoal")
            {
                // name, description, points
                goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
            }
            else if (type == "ChecklistGoal")
            {
                // name, description, points, bonus, amountNeeded, amountDone
                goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])));
            }
        }
        Console.WriteLine("Goals loaded!");
    }
}