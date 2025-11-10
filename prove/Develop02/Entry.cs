using System;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;

    public Entry() { }

    public void CreateEntry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public void Display()
    {
        Console.WriteLine($"{_date} - {_prompt}");
        Console.WriteLine(_response);
        Console.WriteLine();
    }

    public string FormatForFile()
    {
        return $"{_date}|{_prompt}|{_response}";
    }

    public static Entry? FromFileLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line)) return null;

        string[] parts = line.Split('|');
        if (parts.Length != 3) return null;

        var e = new Entry();
        e.CreateEntry(parts[0], parts[1], parts[2]);
        return e;
    }
}
