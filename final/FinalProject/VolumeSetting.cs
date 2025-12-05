public class VolumeSetting
{
    private int _value; // 0–300

    public int Value => _value;          // For display (0–300)
    public float Gain => _value / 100f;  // 100 -> 1.0, 300 -> 3.0

    public VolumeSetting(int start)
    {
        _value = Clamp(start);
    }

    public void Increase()
    {
        _value = Clamp(_value + 10);
    }

    public void Decrease()
    {
        _value = Clamp(_value - 10);
    }

    private int Clamp(int v)
    {
        if (v < 0) return 0;
        if (v > 300) return 300;
        return v;
    }
}
