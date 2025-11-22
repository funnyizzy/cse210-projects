using System;

class ListingActivity : Activity
{
    string[] _prompts;
    Random _random;

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new string[5];
        _prompts[0] = "Who are people that you appreciate?";
        _prompts[1] = "What are personal strengths of yours?";
        _prompts[2] = "Who are people that you have helped this week?";
        _prompts[3] = "When have you felt the Holy Ghost this month?";
        _prompts[4] = "Who are some of your personal heroes?";

        _random = new Random();
    }

    public override void Run()
    {
        Start();

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine("-- " + GetRandomPrompt());
        Console.WriteLine();
        Console.Write("You will begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        Console.WriteLine("Start listing items. Press Enter after each one.");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(item))
            {
                count++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("You listed " + count + " items.");
        End();
    }

    string GetRandomPrompt()
    {
        int index = _random.Next(0, _prompts.Length);
        return _prompts[index];
    }
}
