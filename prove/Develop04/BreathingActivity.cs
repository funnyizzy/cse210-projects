using System;

class BreathingActivity : Activity
{
    int _inBreathSeconds;
    int _outBreathSeconds;

    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        _inBreathSeconds = 4;
        _outBreathSeconds = 6;
    }

    public override void Run()
    {
        Start();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            DoBreathingCycle(endTime);
        }

        End();
    }

    void DoBreathingCycle(DateTime endTime)
    {
        if (DateTime.Now >= endTime)
        {
            return;
        }

        Console.Write("Breathe in... ");
        ShowCountDown(_inBreathSeconds);
        Console.WriteLine();

        if (DateTime.Now >= endTime)
        {
            return;
        }

        Console.Write("Breathe out... ");
        ShowCountDown(_outBreathSeconds);
        Console.WriteLine();
    }
}
