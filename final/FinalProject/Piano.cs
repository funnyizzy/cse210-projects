using System;
using System.Collections.Generic;

public class Piano
{
    private SampleLibrary _library;
    private readonly AudioEngine _audio;

    private readonly Dictionary<char, string> _white = new()
    {
        ['1'] = "C3",
        ['2'] = "D3",
        ['3'] = "E3",
        ['4'] = "F3",
        ['5'] = "G3",
        ['6'] = "A3",
        ['7'] = "B3",
        ['8'] = "C4",
        ['9'] = "D4",
        ['0'] = "E4",
        ['q'] = "F4",
        ['w'] = "G4",
        ['e'] = "A4",
        ['r'] = "B4",
        ['t'] = "C5",
        ['y'] = "D5",
        ['u'] = "E5",
        ['i'] = "F5",
        ['o'] = "G5",
        ['p'] = "A5",
        ['a'] = "B5",
        ['s'] = "C6",
        ['d'] = "D6",
        ['f'] = "E6",
        ['g'] = "F6",
        ['h'] = "G6",
        ['j'] = "A6",
        ['k'] = "B6",
        ['l'] = "C7",
        ['z'] = "D7",
        ['x'] = "E7",
        ['c'] = "F7",
        ['v'] = "G7",
        ['b'] = "A7",
        ['n'] = "B7",
        ['m'] = "C8"
    };
    private readonly Dictionary<char, string> _black = new()
    {
        ['1'] = "Db3",
        ['2'] = "Eb3",
        ['4'] = "Gb3",
        ['5'] = "Ab3",
        ['6'] = "Bb3",
        ['8'] = "Db4",
        ['9'] = "Eb4",

        ['q'] = "Gb4",
        ['w'] = "Ab4",
        ['e'] = "Bb4",

        ['t'] = "Db5",
        ['y'] = "Eb5",
        ['i'] = "Gb5",
        ['o'] = "Ab5",
        ['p'] = "Bb5",

        ['s'] = "Db6",
        ['d'] = "Eb6",
        ['g'] = "Gb6",
        ['h'] = "Ab6",
        ['j'] = "Bb6",

        ['z'] = "Eb7",
        ['c'] = "Gb7",
        ['v'] = "Ab7",
        ['b'] = "Bb7"
    };

    public Piano(SampleLibrary library, AudioEngine audio)
    {
        _library = library;
        _audio = audio;
    }

    public void SetLibrary(SampleLibrary library)
    {
        _library = library;
    }

    public void HandleKey(ConsoleKeyInfo keyInfo)
    {
        char c = char.ToLower(keyInfo.KeyChar);

        bool isShiftDown = (keyInfo.Modifiers & ConsoleModifiers.Shift) != 0;

        string noteName = null;

        if (isShiftDown)
        {
            _black.TryGetValue(c, out noteName);
        }
        else
        {
            _white.TryGetValue(c, out noteName);
        }

        if (noteName == null)
            return;

        var note = _library.GetNote(noteName);
        if (note != null)
        {
            _audio.PlayFile(note.Path);
        }
    }
}
