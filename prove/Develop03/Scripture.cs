using System;

class Scripture
{
    private ScriptureReference _reference;
    private Word[] _words;

    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;

        string[] splitText = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        _words = new Word[splitText.Length];

        for (int i = 0; i < splitText.Length; i++)
        {
            _words[i] = new Word(splitText[i]);
        }
    }

    public void Display()
    {
        Console.WriteLine(_reference.GetDisplayText());
        Console.WriteLine();

        for (int i = 0; i < _words.Length; i++)
        {
            Console.Write(_words[i].GetDisplayText());
            if (i < _words.Length - 1)
            {
                Console.Write(" ");
            }
        }

        Console.WriteLine();
    }

    public void HideRandomWords(int numberToHide, Random random)
    {
        int totalWords = _words.Length;
        int[] visibleIndexes = new int[totalWords];
        int visibleCount = 0;

        for (int i = 0; i < totalWords; i++)
        {
            if (!_words[i].IsHidden())
            {
                visibleIndexes[visibleCount] = i;
                visibleCount++;
            }
        }

        if (visibleCount == 0)
        {
            return;
        }

        if (numberToHide > visibleCount)
        {
            numberToHide = visibleCount;
        }

        for (int n = 0; n < numberToHide; n++)
        {
            int randomPosition = random.Next(0, visibleCount);
            int wordIndex = visibleIndexes[randomPosition];

            _words[wordIndex].Hide();

            visibleIndexes[randomPosition] = visibleIndexes[visibleCount - 1];
            visibleCount--;
        }
    }

    public bool IsCompletelyHidden()
    {
        for (int i = 0; i < _words.Length; i++)
        {
            if (!_words[i].IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}
