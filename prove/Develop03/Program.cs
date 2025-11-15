using System;

class Program
{
    static void Main(string[] args)
    {
        ScriptureReference reference = new ScriptureReference("Helaman", 3, 14);

        string text = "But their records are not all inclusive, for there have been many wars and contentions, and many dissensions; and many who have dissented have gone over unto the Lamanites, and many more have been destroyed beyond number. And it came to pass that I did make a record of these things according to the record of Nephi, which has been kept, and also according to the record which has been kept by the kings, which has been handed down from generation to generation until the present time; and also according to the prophecies which have been spoken by the prophets, even down unto this day.";

        Scripture scripture = new Scripture(reference, text);

        Random random = new Random();
        string userInput = "";

        while (userInput != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            scripture.Display();
            Console.WriteLine();
            Console.Write("Press Enter to hide more words, or type \"quit\" to end: ");

            userInput = Console.ReadLine();
            if (userInput == null)
            {
                userInput = "";
            }

            userInput = userInput.Trim().ToLower();

            if (userInput != "quit")
            {
                scripture.HideRandomWords(3, random);
            }
        }

        Console.Clear();
        scripture.Display();
        Console.WriteLine();
        Console.WriteLine("Program finished.");
    }
}
