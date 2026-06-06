using System;
using System.Collections.Generic;
using System.Threading;

// Base class for all mindfulness activities.
// It holds the shared data (name, description, duration) and the
// shared behaviors (starting message, ending message, and animations).
// The child classes (Breathing, Reflecting, Listing) inherit from this,
// so we do not have to repeat this code in each one.
class Activity
{
    // Private member variables (encapsulation).
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    // Common starting message used by every activity.
    // Shows the name and description, then asks for the duration.
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(4);
    }

    // Common ending message used by every activity.
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed {_duration} seconds of the {_name}.");
        ShowSpinner(4);
        Console.WriteLine();
    }

    // Lets the child classes read the duration the user chose.
    public int GetDuration()
    {
        return _duration;
    }

    // Spinner animation that runs for a number of seconds.
    public void ShowSpinner(int seconds)
    {
        List<string> spinnerSymbols = new List<string>() { "|", "/", "-", "\\" };
        int index = 0;

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < endTime)
        {
            string symbol = spinnerSymbols[index];
            Console.Write(symbol);
            Thread.Sleep(250);
            Console.Write("\b \b");

            index++;
            if (index >= spinnerSymbols.Count)
            {
                index = 0;
            }
        }
    }

    // Countdown animation that shows the numbers going down to zero.
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}