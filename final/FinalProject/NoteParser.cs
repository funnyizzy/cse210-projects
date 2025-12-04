using System;

public static class NoteParser
{
    // Parses names like C2, Db2, Eb3, Gb4, Ab0, Bb1...
    public static bool TryParsePitch(string noteName, out int pitch)
    {
        pitch = 0;
        if (string.IsNullOrWhiteSpace(noteName))
            return false;

        noteName = noteName.Trim();

        // Letter
        char letter = noteName[0];
        if ("ABCDEFG".IndexOf(letter) < 0)
            return false;

        int index = 1;
        bool flat = false;

        // Optional 'b'
        if (index < noteName.Length && noteName[index] == 'b')
        {
            flat = true;
            index++;
        }

        if (index >= noteName.Length)
            return false;

        // Remaining = octave number
        if (!int.TryParse(noteName.Substring(index), out int octave))
            return false;

        int baseOffset = letter switch
        {
            'C' => 0,
            'D' => 2,
            'E' => 4,
            'F' => 5,
            'G' => 7,
            'A' => 9,
            'B' => 11,
            _ => 0
        };

        if (flat)
        {
            baseOffset -= 1;
        }

        pitch = octave * 12 + baseOffset;
        return true;
    }
}
