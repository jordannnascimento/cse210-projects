using System;

// Base class for every goal.
// It is abstract because we never make a plain "Goal",
// only a Simple, Eternal, or Checklist goal.
public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    // Getters so the other classes can read these private values.
    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    // Each goal type decides what happens when it is recorded.
    public abstract int RecordEvent();

    // Each goal type decides if it is complete.
    public abstract bool IsComplete();

    // How the goal looks in the list. Child classes can change this.
    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description})";
    }

    // How the goal is written to the save file.
    public abstract string GetStringRepresentation();
}