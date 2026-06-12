// A goal that is done only one time (for example: run a marathon).
public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, string description, int points, bool completed = false)
        : base(name, description, points)
    {
        _completed = completed;
    }

    public override int RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
            return GetPoints();
        }
        return 0; // already done, no more points
    }

    public override bool IsComplete()
    {
        return _completed;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{GetName()},{GetDescription()},{GetPoints()},{_completed}";
    }
}