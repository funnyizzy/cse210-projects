using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private readonly List<Entry> _entries = new();
    private const string FileName = "Journal.txt";

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries to display.\n");
            return;
        }

        foreach (var e in _entries)
        {
            e.Display();
        }
    }

    public void SaveToFile()
    {
        using var writer = new StreamWriter(FileName);
        foreach (var e in _entries)
        {
            writer.WriteLine(e.FormatForFile());
        }
        Console.WriteLine($"Journal saved to {FileName}.\n");
    }

    public void ReadFromFile()
    {
        if (!File.Exists(FileName))
        {
            Console.WriteLine($"File {FileName} not found.\n");
            return;
        }

        _entries.Clear();

        foreach (var line in File.ReadLines(FileName))
        {
            var e = Entry.FromFileLine(line);
            if (e != null) _entries.Add(e);
        }

        Console.WriteLine($"Journal loaded from {FileName} ({_entries.Count} entries).\n");
    }
}
