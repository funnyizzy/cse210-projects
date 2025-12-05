using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Title = "Console Piano (Level 1)";

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

        // 0–300, step of 10; 100 = normal (1.0x), 300 = 3.0x
        VolumeSetting volume = new VolumeSetting(100);
        audio.Gain = volume.Gain;

        Piano piano = new Piano(current, audio);

        Console.WriteLine("Loaded Soundfonts:");
        for (int i = 0; i < banks.Count; i++)
            Console.WriteLine($"  {i + 1}. {banks[i].BankName}");

        Console.WriteLine();
        Console.WriteLine("Controls:");
        Console.WriteLine("  Notes        = 1–0, qwerty, asdfghjkl, zxcvbnm (Shift = black keys)");
        Console.WriteLine("  Soundfont    = [ (previous) / ] (next)");
        Console.WriteLine("  Volume       = LeftArrow (down 10) / RightArrow (up 10)");
        Console.WriteLine("  ESC          = Quit");
        Console.WriteLine();

        Console.WriteLine($"Bank: {current.BankName}");
        Console.WriteLine($"Volume: {volume.Value}");

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
                break;

            if (key.Key == ConsoleKey.LeftArrow)
            {
                volume.Decrease();
                audio.Gain = volume.Gain;
                Console.WriteLine($"Volume: {volume.Value}");
                continue;
            }

            if (key.Key == ConsoleKey.RightArrow)
            {
                volume.Increase();
                audio.Gain = volume.Gain;
                Console.WriteLine($"Volume: {volume.Value}");
                continue;
            }

            if (key.KeyChar == '[')
            {
                activeBank--;
                if (activeBank < 0)
                    activeBank = banks.Count - 1;

                current = banks[activeBank];
                piano.SetLibrary(current);
                Console.WriteLine($"Switched to soundfont: {current.BankName}");
                continue;
            }

            if (key.KeyChar == ']')
            {
                activeBank++;
                if (activeBank >= banks.Count)
                    activeBank = 0;

                current = banks[activeBank];
                piano.SetLibrary(current);
                Console.WriteLine($"Switched to soundfont: {current.BankName}");
                continue;
            }

            piano.HandleKey(key);
        }

        Console.WriteLine("Goodbye.");
    }
}
