using System;

public class Entry
{
    // Attributes (members) of the Entry class
    public string _date;
    public string _promptText;
    public string _entryText;

    // Method responsible for displaying the input on the screen.
    // Keeping the Display within the Entry follows the principle of abstraction:
    // If we change what the Entry stores, only that class needs to be updated.
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}\n");
    }
}