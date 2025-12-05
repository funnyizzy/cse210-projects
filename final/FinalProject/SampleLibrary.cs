using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class SampleLibrary
{
    private readonly Dictionary<string, SampleNote> _byName;
    private readonly Dictionary<int, SampleNote> _byPitch;
    private readonly int _minPitch;
    private readonly int _maxPitch;

    public string BankName { get; }

    public SampleLibrary(string bankFolder, string bankName)
    {
        BankName = bankName;

        if (!Directory.Exists(bankFolder))
            throw new DirectoryNotFoundException($"Soundfont folder not found: {bankFolder}");

        string[] files = Directory.GetFiles(bankFolder, "*.mp3");

        var notes = new List<SampleNote>();

        foreach (string path in files)
        {
            string name = Path.GetFileNameWithoutExtension(path);
            if (!NoteParser.TryParsePitch(name, out int pitch))
                continue;

            notes.Add(new SampleNote(name, path, pitch));
        }

        if (!notes.Any())
            throw new Exception($"No valid notes in soundfont '{bankName}'.");

        if (!notes.Any(n => n.Name.Equals("C2", StringComparison.OrdinalIgnoreCase)))
            throw new Exception($"Soundfont '{bankName}' does not contain C2.mp3.");

        _byName = notes.ToDictionary(n => n.Name, n => n, StringComparer.OrdinalIgnoreCase);
        _byPitch = notes.ToDictionary(n => n.Pitch, n => n);

        _minPitch = _byPitch.Keys.Min();
        _maxPitch = _byPitch.Keys.Max();
    }

    public static string GetSoundsRoot()
    {
        string baseDir = AppContext.BaseDirectory;
        string p1 = Path.Combine(baseDir, "sounds");
        if (Directory.Exists(p1)) return p1;

        string root = Path.GetFullPath(Path.Combine(baseDir, "..", "..", ".."));
        return Path.Combine(root, "sounds");
    }

    public static List<SampleLibrary> LoadAllBanks()
    {
        string root = GetSoundsRoot();
        var list = new List<SampleLibrary>();

        foreach (var folder in Directory.GetDirectories(root))
        {
            string bankName = Path.GetFileName(folder);

            try
            {
                var lib = new SampleLibrary(folder, bankName);
                list.Add(lib);
            }
            catch
            {
            }
        }

        if (list.Count == 0)
            throw new Exception("No valid soundfonts found inside /sounds.");

        return list;
    }

    public SampleNote Transpose(string name, int semitones)
    {
        if (!_byName.TryGetValue(name, out var n))
            return null;

        int pitch = n.Pitch + semitones;

        if (pitch < _minPitch) pitch = _minPitch;
        if (pitch > _maxPitch) pitch = _maxPitch;

        return _byPitch.TryGetValue(pitch, out var r) ? r : null;
    }

    public bool HasNote(string name) => _byName.ContainsKey(name);

    public SampleNote GetNote(string name)
    {
        return _byName.TryGetValue(name, out var n) ? n : null;
    }
}
