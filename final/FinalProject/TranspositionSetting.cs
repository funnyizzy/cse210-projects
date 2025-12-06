public class TranspositionSetting
{
    private int _semitoneOffset;

    public TranspositionSetting(int semitoneOffset = 0)
    {
        _semitoneOffset = semitoneOffset;
    }

    public int GetOffset()
    {
        return _semitoneOffset;
    }

    public void Increase()
    {
        _semitoneOffset++;
    }

    public void Decrease()
    {
        _semitoneOffset--;
    }

    public void Reset()
    {
        _semitoneOffset = 0;
    }
}
