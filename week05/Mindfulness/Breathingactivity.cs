using System;

// Breathing activity: alternates "Breathe in..." and "Breathe out..."
// with a countdown after each message, until the time is up.
class BreathingActivity : Activity
{
    // We pass the name and description up to the base class constructor.
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            ShowCountDown(4);
            Console.WriteLine();

            // Check the time again so we do not breathe out after time is up.
            if (DateTime.Now < endTime)
            {
                Console.Write("Breathe out... ");
                ShowCountDown(6);
                Console.WriteLine();
            }
        }

        DisplayEndingMessage();
    }
}