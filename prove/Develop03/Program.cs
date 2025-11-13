using System;

class Program
{
    static void Main(string[] args)
    {
        Word myWord = new Word("Hello, World!");
        myWord.DisplayWord();
        Console.WriteLine(myWord.LocalGetWordString());
        myWord.HideWord();
        if (myWord.IsHidden())
        {
            Console.WriteLine("word is hidden.");
        }

        Console.WriteLine(myWord.LocalGetWordString());
        myWord.DisplayWord();
    }
}