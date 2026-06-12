// A goal that must be done a certain number of times (for example:
// attend the temple 10 times). You get points each time, plus a
// bonus when you reach the total.
public class ChecklistGoal : Goal
{
    private int _amountNeeded;
    private int _amountDone;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int bonus, int amountNeeded, int amountDone = 0)
        : base(name, description, points)
    {
        _bonus = bonus;
        _amountNeeded = amountNeeded;
        _amountDone = amountDone;
    }

    public override int RecordEvent()
    {
        _amountDone++;
        if (_amountDone == _amountNeeded)
        {
            return GetPoints() + _bonus; // bonus on the last time
        }
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _amountDone >= _amountNeeded;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {GetName()} ({GetDescription()}) -- Completed {_amountDone}/{_amountNeeded} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetName()},{GetDescription()},{GetPoints()},{_bonus},{_amountNeeded},{_amountDone}";
    }
}