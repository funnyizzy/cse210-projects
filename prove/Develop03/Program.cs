using System;

class Program
{
    static void Main(string[] args)
    {

        /* Stretch: allows the user to choose from multiple scriptures */
        ScriptureReference reference1 = new ScriptureReference("Helaman", 3, 14);
        string text1 = "But their records are not all inclusive, for there have been many wars and contentions, and many dissensions; and many who have dissented have gone over unto the Lamanites, and many more have been destroyed beyond number. And it came to pass that I did make a record of these things according to the record of Nephi, which has been kept, and also according to the record which has been kept by the kings, which has been handed down from generation to generation until the present time; and also according to the prophecies which have been spoken by the prophets, even down unto this day.";

        ScriptureReference reference2 = new ScriptureReference("Proverbs", 3, 5, 6);
        string text2 = "Trust in the Lord with all thine heart; and lean not unto thine own understanding.";

        ScriptureReference reference3 = new ScriptureReference("John", 3, 16);
        string text3 = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";

        ScriptureReference reference4 = new ScriptureReference("2 Nephi", 2, 25);
        string text4 = "Adam fell that men might be; and men are, that they might have joy.";

        ScriptureReference reference5 = new ScriptureReference("Moroni", 10, 4);
        string text5 = "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost.";

        Scripture[] scriptures = new Scripture[5];
        scriptures[0] = new Scripture(reference1, text1);
        scriptures[1] = new Scripture(reference2, text2);
        scriptures[2] = new Scripture(reference3, text3);
        scriptures[3] = new Scripture(reference4, text4);
        scriptures[4] = new Scripture(reference5, text5);

        Console.WriteLine("Choose a scripture to practice:");
        Console.WriteLine("1. " + reference1.GetDisplayText());
        Console.WriteLine("2. " + reference2.GetDisplayText());
        Console.WriteLine("3. " + reference3.GetDisplayText());
        Console.WriteLine("4. " + reference4.GetDisplayText());
        Console.WriteLine("5. " + reference5.GetDisplayText());
        Console.Write("Enter a number (1-5): ");

        string choiceInput = Console.ReadLine();
        int choice = 1;
        int.TryParse(choiceInput, out choice);

        if (choice < 1 || choice > 5)
        {
            choice = 1;
        }

        Scripture scripture = scriptures[choice - 1];

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
