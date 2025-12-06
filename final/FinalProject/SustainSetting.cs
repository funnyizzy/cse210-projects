public class SustainSetting
{
    private bool _isOn;

    public SustainSetting(bool isOn)
    {
        _isOn = isOn;
    }

    public bool IsOn()
    {
        return _isOn;
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
}
