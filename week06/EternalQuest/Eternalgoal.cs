// A goal that is never complete (for example: read the scriptures).
// Every time you record it, you get points.
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return GetPoints(); // always gives points
    }

    public override bool IsComplete()
    {
        return false; // never finishes
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{GetName()},{GetDescription()},{GetPoints()}";
    }
}