using System;

public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
    }

    public EternalGoal(string shortName, string description, int points, bool ignoredIsComplete)
        : base(shortName, description, points)
    {
    }

    public override int RecordEvent()
    {
        return Points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStatusString()
    {
        return $"[ ] {ShortName} ({Description}) (Eternal)";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{ShortName}|{Description}|{Points}|false";
    }
}
