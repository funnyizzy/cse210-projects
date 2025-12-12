public class SustainSetting : PianoSetting
{
    private bool _isOn;

    public bool IsOn => _isOn;

    public SustainSetting(bool isOn) : base("Sustain")
    {
        _isOn = isOn;
    }

    public void Toggle()
    {
        _isOn = !_isOn;
    }

    public void Enable()
    {
        _isOn = true;
    }

    public void Disable()
    {
        _isOn = false;
    }

    public override string Describe()
    {
        return $"{Name}: {(_isOn ? "On" : "Off")}";
    }
}
