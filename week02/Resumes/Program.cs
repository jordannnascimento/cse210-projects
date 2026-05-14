using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Graphic Designer";
        job1._company = "iAi - Institute for AI Transformation";
        job1._startYear = 2026;
        job1._isCurrent = true;

        Job job2 = new Job();
        job2._jobTitle = "Graphic Designer";
        job2._company = "Index-IBL";
        job2._startYear = 2022;
        job2._endYear = 2026;

        Resume myResume = new Resume();
        myResume._name = "Jordann Nascimento";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}