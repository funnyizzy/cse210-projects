// Stretch: tracks total time spent in all activities during this session.
using System;

class Program
{
    static Activity[] _activities = new Activity[3];
    static int _totalTime = 0;

    static void Main(string[] args)
    {
        _activities[0] = new BreathingActivity();
        _activities[1] = new ReflectionActivity();
        _activities[2] = new ListingActivity();

        int choice = 0;

        while (choice != 4)
        {
            choice = ShowMenu();
            RunActivity(choice);
        }

        if (_totalTime > 0)
        {
            Console.WriteLine("You spent a total of " + _totalTime + " seconds in mindfulness activities.");
        }

        Console.WriteLine("Goodbye.");
    }

    static int ShowMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Start breathing activity");
        Console.WriteLine("  2. Start reflection activity");
        Console.WriteLine("  3. Start listing activity");
        Console.WriteLine("  4. Quit");
        Console.Write("Select a choice from the menu: ");

        string input = Console.ReadLine();
        int choice;

        if (!int.TryParse(input, out choice))
        {
            choice = 0;
        }

        return choice;
    }

    static void RunActivity(int choice)
    {
        Console.Clear();

        if (choice >= 1 && choice <= 3)
        {
            Activity activity = _activities[choice - 1];
            activity.Run();
            _totalTime += activity.GetDuration();
            Console.WriteLine("Total time so far: " + _totalTime + " seconds.");
            Console.WriteLine();
        }
        else if (choice == 4)
        {
        }
        else
        {
            Console.WriteLine("Please choose a valid option.");
        }
    }
}
