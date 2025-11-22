using System;

class ReflectionActivity : Activity
{
    string[] _prompts;
    string[] _questions;
    Random _random;

    public ReflectionActivity() : base(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new string[4];
        _prompts[0] = "Think of a time when you stood up for someone else.";
        _prompts[1] = "Think of a time when you did something really difficult.";
        _prompts[2] = "Think of a time when you helped someone in need.";
        _prompts[3] = "Think of a time when you did something truly selfless.";

        _questions = new string[9];
        _questions[0] = "Why was this experience meaningful to you?";
        _questions[1] = "Have you ever done anything like this before?";
        _questions[2] = "How did you get started?";
        _questions[3] = "How did you feel when it was complete?";
        _questions[4] = "What made this time different than other times when you were not as successful?";
        _questions[5] = "What is your favorite thing about this experience?";
        _questions[6] = "What could you learn from this experience that applies to other situations?";
        _questions[7] = "What did you learn about yourself through this experience?";
        _questions[8] = "How can you keep this experience in mind in the future?";

        _random = new Random();
    }

    public override void Run()
    {
        Start();

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine("-- " + GetRandomPrompt());
        Console.WriteLine();
        Console.Write("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.WriteLine(GetRandomQuestion());
            ShowSpinner(5);
        }

        End();
    }

    string GetRandomPrompt()
    {
        int index = _random.Next(0, _prompts.Length);
        return _prompts[index];
    }

    string GetRandomQuestion()
    {
        int index = _random.Next(0, _questions.Length);
        return _questions[index];
    }
}
