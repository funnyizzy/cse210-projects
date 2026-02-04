using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Title = "Console Piano";

        List<SampleLibrary> banks;

        try
        {
            banks = SampleLibrary.LoadAllBanks();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey(true);
            return;
        }

        int activeBank = 0;
        SampleLibrary current = banks[activeBank];

        using AudioEngine audio = new AudioEngine();

        VolumeSetting volume = new VolumeSetting(100);
        SustainSetting sustain = new SustainSetting(true);
        TranspositionSetting transposition = new TranspositionSetting(0);

        List<PianoSetting> settings = new()
        {
            volume,
            sustain,
            transposition
        };

        audio.Gain = volume.Gain;

        Piano piano = new Piano(current, audio, transposition, sustain);

        void PrintSettings()
        {
            Console.WriteLine();
            Console.WriteLine($"Bank: {current.BankName}");
            foreach (var setting in settings)
            {
                Console.WriteLine(setting.Describe());
            }
            Console.WriteLine();
        }

        Console.WriteLine("Loaded Soundfonts:");
        for (int i = 0; i < banks.Count; i++)
            Console.WriteLine($"  {i + 1}. {banks[i].BankName}");

        Console.WriteLine();
        Console.WriteLine("Controls:");
        Console.WriteLine("  Notes        = 1–0, qwerty, asdfghjkl, zxcvbnm (Shift = black keys)");
        Console.WriteLine("  Soundfont    = [ (previous) / ] (next)");
        Console.WriteLine("  Volume       = LeftArrow (-) / RightArrow (+)");
        Console.WriteLine("  Transpose    = UpArrow (+1 semitone) / DownArrow (-1 semitone)");
        Console.WriteLine("  Sustain      = Spacebar (toggle sustain on/off)");
        Console.WriteLine("  ESC          = Quit");
        Console.WriteLine();

        PrintSettings();

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
                break;

            if (key.Key == ConsoleKey.LeftArrow)
            {
                volume.Decrease();
                audio.Gain = volume.Gain;
                PrintSettings();
                continue;
            }

            if (key.Key == ConsoleKey.RightArrow)
            {
                volume.Increase();
                audio.Gain = volume.Gain;
                PrintSettings();
                continue;
            }

            if (key.Key == ConsoleKey.UpArrow)
            {
                transposition.Increase();
                PrintSettings();
                continue;
            }

            if (key.Key == ConsoleKey.DownArrow)
            {
                transposition.Decrease();
                PrintSettings();
                continue;
            }

            if (key.Key == ConsoleKey.Spacebar)
            {
                sustain.Toggle();
                PrintSettings();
                continue;
            }

            if (key.KeyChar == '[')
            {
                activeBank--;
                if (activeBank < 0)
                    activeBank = banks.Count - 1;

                current = banks[activeBank];
                piano.SetLibrary(current);
                PrintSettings();
                continue;
            }

            if (key.KeyChar == ']')
            {
                activeBank++;
                if (activeBank >= banks.Count)
                    activeBank = 0;

                current = banks[activeBank];
                piano.SetLibrary(current);
                PrintSettings();
                continue;
            }

            piano.HandleKey(key);
        }

        Console.WriteLine("Goodbye.");
    }
}
