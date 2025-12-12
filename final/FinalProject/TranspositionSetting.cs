public class TranspositionSetting : PianoSetting
{
    private int _semitoneOffset;

    public int Offset => _semitoneOffset;

    public TranspositionSetting(int semitoneOffset = 0) : base("Transposition")
    {
        _semitoneOffset = semitoneOffset;
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

    public override string Describe()
    {
        return $"{Name}: {Offset} semitones";
    }
}
