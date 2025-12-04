using System;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    protected Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public string ShortName
    {
        get { return _shortName; }
    }

    public string Description
    {
        get { return _description; }
    }

    public int Points
    {
        get { return _points; }
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStatusString();
    public abstract string GetStringRepresentation();
}
