public class SampleNote
{
    public string Name { get; }
    public string Path { get; }
    public int Pitch { get; }

    public SampleNote(string name, string path, int pitch)
    {
        Name = name;
        Path = path;
        Pitch = pitch;
    }
}
