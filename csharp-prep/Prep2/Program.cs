using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What's your grade: ");
        string input = Console.ReadLine();
        int percent = int.Parse(input);
        
        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else if (percent < 60)
        {
            letter = "F";
        }

        Console.WriteLine($"Your letter grade is: {letter}");
         if (percent >= 70)
        {
            Console.WriteLine("you passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time.");
        }
    }
}