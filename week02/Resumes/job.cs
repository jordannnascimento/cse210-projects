public class Job
{
    public string _jobTitle = "";
    public string _company = "";
    public int _startYear = 0;
    public int _endYear = 0;
    public bool _isCurrent = false;

    public void Display()
    {
        string end = _isCurrent ? "Current" : _endYear.ToString();
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{end}");
    }
}