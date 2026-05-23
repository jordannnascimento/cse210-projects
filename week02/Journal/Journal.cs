using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // List of entries. Always accessed through the class methods.
    public List<Entry> _entries = new List<Entry>();

    // Separator used to save/load the file.
    // We use "~|~" because it is unlikely to appear in user content.
    private string _separator = "~|~";

    // Adds a new entry to the journal.
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Displays all entries by calling the Display event for each one.
    // The Journal does not need to know the details of how an Entry is displayed.
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Saves all entries to a file.
    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}{_separator}{entry._promptText}{_separator}{entry._entryText}");
            }
        }
        Console.WriteLine($"Journal saved to {file}\n");
    }

    // Loads entries from a file, replacing the current ones.
    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"File {file} not found.\n");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split(_separator);
            if (parts.Length == 3)
            {
                Entry entry = new Entry();
                entry._date = parts[0];
                entry._promptText = parts[1];
                entry._entryText = parts[2];
                _entries.Add(entry);
            }
        }
        Console.WriteLine($"Journal loaded from {file}\n");
    }
}