public abstract class PianoSetting
{
    public string Name { get; }

    protected PianoSetting(string name)
    {
        Name = name;
    }

    public abstract string Describe();
}
