using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
/* for stretch goal I added a level system */

    private static List<Goal> _goals = new List<Goal>();
    private static int _score = 0;

    public static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            int level = GetLevelFromScore(_score);
            Console.WriteLine($"You have {_score} points. (Level {level})");
            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please choose a valid option (1-6).");
                    break;
            }
        }
    }

    private static void CreateNewGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (typeChoice == "1")
        {
            Goal goal = new SimpleGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (typeChoice == "2")
        {
            Goal goal = new EternalGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (typeChoice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int targetCount = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for completing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            Goal goal = new ChecklistGoal(name, description, points, targetCount, bonus);
            _goals.Add(goal);
        }
        else
        {
            Console.WriteLine("Unknown goal type.");
        }
    }

    private static void ListGoals()
    {
        Console.WriteLine("The goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("  (No goals yet)");
        }
        else
        {
            int index = 1;
            foreach (Goal goal in _goals)
            {
                Console.WriteLine($"{index}. {goal.GetStatusString()}");
                index++;
            }
        }
    }

    private static void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", filename);

        List<string> lines = new List<string>();
        lines.Add(_score.ToString());

        foreach (Goal goal in _goals)
        {
            lines.Add(goal.GetStringRepresentation());
        }

        File.WriteAllLines(fullPath, lines);
        Console.WriteLine($"Goals saved to {fullPath}");
    }

    private static void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", filename);

        if (!File.Exists(fullPath))
        {
            Console.WriteLine("That file does not exist.");
            return;
        }

        string[] lines = File.ReadAllLines(fullPath);
        _goals.Clear();

        if (lines.Length > 0)
        {
            _score = int.Parse(lines[0]);
        }

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(':');
            if (parts.Length != 2)
            {
                continue;
            }

            string typeName = parts[0];
            string data = parts[1];
            string[] dataParts = data.Split('|');

            if (typeName == "SimpleGoal")
            {
                string name = dataParts[0];
                string description = dataParts[1];
                int points = int.Parse(dataParts[2]);
                bool isComplete = bool.Parse(dataParts[3]);

                Goal goal = new SimpleGoal(name, description, points, isComplete);
                _goals.Add(goal);
            }
            else if (typeName == "EternalGoal")
            {
                string name = dataParts[0];
                string description = dataParts[1];
                int points = int.Parse(dataParts[2]);

                Goal goal = new EternalGoal(name, description, points);
                _goals.Add(goal);
            }
            else if (typeName == "ChecklistGoal")
            {
                string name = dataParts[0];
                string description = dataParts[1];
                int points = int.Parse(dataParts[2]);
                int targetCount = int.Parse(dataParts[3]);
                int bonus = int.Parse(dataParts[4]);
                int currentCount = int.Parse(dataParts[5]);
                bool isComplete = bool.Parse(dataParts[6]);

                Goal goal = new ChecklistGoal(name, description, points,
                    targetCount, bonus, currentCount, isComplete);
                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals were loaded.");
    }

    private static void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to record.");
            return;
        }

        Console.WriteLine("Which goal did you accomplish?");
        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{index}. {goal.ShortName}");
            index++;
        }

        Console.Write("Enter the number of the goal: ");
        string input = Console.ReadLine();
        int goalIndex = int.Parse(input);
        goalIndex--;

        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            Console.WriteLine("That is not a valid goal number.");
            return;
        }

        Goal chosenGoal = _goals[goalIndex];

        int oldScore = _score;
        int pointsGained = chosenGoal.RecordEvent();
        _score += pointsGained;

        Console.WriteLine($"You received {pointsGained} points!");

        CheckForLevelUp(oldScore, _score);
    }

    private static int GetLevelFromScore(int score)
    {
        int level = 1 + score / 1000;
        return level;
    }

    private static void CheckForLevelUp(int oldScore, int newScore)
    {
        int oldLevel = GetLevelFromScore(oldScore);
        int newLevel = GetLevelFromScore(newScore);

        if (newLevel > oldLevel)
        {
            Console.WriteLine();
            Console.WriteLine($"*** Congratulations! You reached level {newLevel}! ***");
            Console.WriteLine();
        }
    }
}
