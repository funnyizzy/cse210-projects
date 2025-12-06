public class VolumeSetting
{
    private int _value;

    public int Value => _value;
    public float Gain => _value / 100f;

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
