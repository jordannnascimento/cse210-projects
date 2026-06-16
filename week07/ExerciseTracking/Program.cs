using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create one activity of each type
        Running running = new Running(new DateTime(2022, 11, 3), 30, 3.0);
        Cycling cycling = new Cycling(new DateTime(2022, 11, 3), 30, 6.0);
        Swimming swimming = new Swimming(new DateTime(2022, 11, 3), 30, 60);

        // Put them all in the same list
        List<Activity> activities = new List<Activity>();
        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        // Go through the list and show the summary of each one
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}