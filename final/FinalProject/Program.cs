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
        Piano piano = new Piano(current, audio);

        Console.WriteLine("Loaded Soundfonts:");
        for (int i = 0; i < banks.Count; i++)
            Console.WriteLine($"  {i + 1}. {banks[i].BankName}");

        Console.WriteLine();
        Console.WriteLine("Controls:");
        Console.WriteLine("  Notes        = qwerty / asdfghjkl");
        Console.WriteLine("  Soundfont    = [ (previous) / ] (next)");
        Console.WriteLine("  ESC          = Quit");
        Console.WriteLine();

        Console.WriteLine($"Bank: {current.BankName}");

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
                break;

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
