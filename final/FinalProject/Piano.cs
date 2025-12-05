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
        char layoutChar;

        switch (keyInfo.Key)
        {
            case ConsoleKey.D1: layoutChar = '1'; break;
            case ConsoleKey.D2: layoutChar = '2'; break;
            case ConsoleKey.D3: layoutChar = '3'; break;
            case ConsoleKey.D4: layoutChar = '4'; break;
            case ConsoleKey.D5: layoutChar = '5'; break;
            case ConsoleKey.D6: layoutChar = '6'; break;
            case ConsoleKey.D7: layoutChar = '7'; break;
            case ConsoleKey.D8: layoutChar = '8'; break;
            case ConsoleKey.D9: layoutChar = '9'; break;
            case ConsoleKey.D0: layoutChar = '0'; break;

            case ConsoleKey.Q: layoutChar = 'q'; break;
            case ConsoleKey.W: layoutChar = 'w'; break;
            case ConsoleKey.E: layoutChar = 'e'; break;
            case ConsoleKey.R: layoutChar = 'r'; break;
            case ConsoleKey.T: layoutChar = 't'; break;
            case ConsoleKey.Y: layoutChar = 'y'; break;
            case ConsoleKey.U: layoutChar = 'u'; break;
            case ConsoleKey.I: layoutChar = 'i'; break;
            case ConsoleKey.O: layoutChar = 'o'; break;
            case ConsoleKey.P: layoutChar = 'p'; break;

            case ConsoleKey.A: layoutChar = 'a'; break;
            case ConsoleKey.S: layoutChar = 's'; break;
            case ConsoleKey.D: layoutChar = 'd'; break;
            case ConsoleKey.F: layoutChar = 'f'; break;
            case ConsoleKey.G: layoutChar = 'g'; break;
            case ConsoleKey.H: layoutChar = 'h'; break;
            case ConsoleKey.J: layoutChar = 'j'; break;
            case ConsoleKey.K: layoutChar = 'k'; break;
            case ConsoleKey.L: layoutChar = 'l'; break;

            case ConsoleKey.Z: layoutChar = 'z'; break;
            case ConsoleKey.X: layoutChar = 'x'; break;
            case ConsoleKey.C: layoutChar = 'c'; break;
            case ConsoleKey.V: layoutChar = 'v'; break;
            case ConsoleKey.B: layoutChar = 'b'; break;
            case ConsoleKey.N: layoutChar = 'n'; break;
            case ConsoleKey.M: layoutChar = 'm'; break;

            default:
                layoutChar = char.ToLower(keyInfo.KeyChar);
                break;
        }

        bool isShiftDown = (keyInfo.Modifiers & ConsoleModifiers.Shift) != 0;

        string noteName = null;

        if (isShiftDown)
        {
            _black.TryGetValue(layoutChar, out noteName);
        }
        else
        {
            _white.TryGetValue(layoutChar, out noteName);
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
