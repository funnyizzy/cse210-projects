using System;
using System.Collections.Generic;

public class Piano
{
    private SampleLibrary _library;
    private readonly AudioEngine _audio;

    private readonly Dictionary<char, string> _white = new()
    {
        ['1'] = "C2",
        ['2'] = "D2",
        ['3'] = "E2",
        ['4'] = "F2",
        ['5'] = "G2",
        ['6'] = "A2",
        ['7'] = "B2",
        ['8'] = "C3",
        ['9'] = "D3",
        ['0'] = "E3",

        ['q'] = "F3",
        ['w'] = "G3",
        ['e'] = "A3",
        ['r'] = "B3",
        ['t'] = "C4",
        ['y'] = "D4",
        ['u'] = "E4",
        ['i'] = "F4",
        ['o'] = "G4",
        ['p'] = "A4",

        ['a'] = "B4",
        ['s'] = "C5",
        ['d'] = "D5",
        ['f'] = "E5",
        ['g'] = "F5",
        ['h'] = "G5",
        ['j'] = "A5",
        ['k'] = "B5",
        ['l'] = "C6",

        ['z'] = "D6",
        ['x'] = "E6",
        ['c'] = "F6",
        ['v'] = "G6",
        ['b'] = "A6",
        ['n'] = "B6",
        ['m'] = "C7"
    };

    private readonly Dictionary<char, string> _black = new()
    {
        ['1'] = "Db2",
        ['2'] = "Eb2",
        ['4'] = "Gb2",
        ['5'] = "Ab2",
        ['6'] = "Bb2",

        ['8'] = "Db3",
        ['9'] = "Eb3",

        ['q'] = "Gb3",
        ['w'] = "Ab3",
        ['e'] = "Bb3",

        ['t'] = "Db4",
        ['y'] = "Eb4",
        ['i'] = "Gb4",
        ['o'] = "Ab4",
        ['p'] = "Bb4",

        ['s'] = "Db5",
        ['d'] = "Eb5",
        ['g'] = "Gb5",
        ['h'] = "Ab5",
        ['j'] = "Bb5",
        ['l'] = "Db6",

        ['z'] = "Eb6",
        ['c'] = "Gb6",
        ['v'] = "Ab6",
        ['b'] = "Bb6"
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
