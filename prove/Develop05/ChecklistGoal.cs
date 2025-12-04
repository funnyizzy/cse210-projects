using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;
    private bool _isComplete;

    public ChecklistGoal(string shortName, string description, int points, int targetCount, int bonus)
        : base(shortName, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = 0;
        _isComplete = false;
    }

    public ChecklistGoal(string shortName, string description, int points,
        int targetCount, int bonus, int currentCount, bool isComplete)
        : base(shortName, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = currentCount;
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }

        _currentCount++;
        int pointsEarned = Points;

        if (_currentCount >= _targetCount && !_isComplete)
        {
            _isComplete = true;
            pointsEarned += _bonus;
        }

        return pointsEarned;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStatusString()
    {
        string checkbox = _isComplete ? "[X]" : "[ ]";
        return $"{checkbox} {ShortName} ({Description}) -- Completed {_currentCount}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{ShortName}|{Description}|{Points}|{_targetCount}|{_bonus}|{_currentCount}|{_isComplete}";
    }
}
