using System;

public static class NoteParser
{
    public static bool TryParsePitch(string noteName, out int pitch)
    {
        pitch = 0;
        if (string.IsNullOrWhiteSpace(noteName))
            return false;

        noteName = noteName.Trim();

        char letter = noteName[0];
        if ("ABCDEFG".IndexOf(letter) < 0)
            return false;

        int index = 1;
        int accidentalOffset = 0;

        if (index < noteName.Length)
        {
            char acc = noteName[index];
            if (acc == 'b')
            {
                accidentalOffset = -1;
                index++;
            }
            else if (acc == '#')
            {
                accidentalOffset = 1;
                index++;
            }
        }

        if (index >= noteName.Length)
            return false;

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

        baseOffset += accidentalOffset;

        pitch = octave * 12 + baseOffset;
        return true;
    }
}
