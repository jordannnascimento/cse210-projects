using System;

public class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // Getter for minutes so derived classes can use it
    public int GetMinutes()
    {
        return _minutes;
    }

    // These methods are declared here but do nothing yet.
    // Each child class will override them.
    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    // Each child class tells its own name
    public virtual string GetActivityName()
    {
        return "Activity";
    }

    // Summary is defined here and uses the other methods
    public string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetActivityName()} ({_minutes} min)- " +
               $"Distance {GetDistance():F1} miles, " +
               $"Speed {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F1} min per mile";
    }
}