using System;

class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    void WaitSeconds(double seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < endTime)
        {
        }
    }

    public void Start()
    {
        Console.WriteLine();
        Console.WriteLine("Starting " + _name + ".");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        SetDurationUser();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void End()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine("You have completed " + _name + " for " + _duration + " seconds.");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void SetDurationUser()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();
        int seconds;

        if (!int.TryParse(input, out seconds) || seconds <= 0)
        {
            seconds = 10;
        }

        _duration = seconds;
    }

    public virtual void Run()
    {
    }

    public void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int frameIndex = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[frameIndex]);
            WaitSeconds(0.2);
            Console.Write("\b \b");
            frameIndex++;

            if (frameIndex >= frames.Length)
            {
                frameIndex = 0;
            }
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            WaitSeconds(1.0);
            Console.Write("\b \b");
        }
    }

    public int GetDuration()
    {
        return _duration;
    }
}
