using System.Data.SqlTypes;

class Word
{
    private string _word;
    private bool _isHidden;

    public Word(string word)
    {
        _word = word;
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public void HideWord()
    {
        _isHidden = true;
    }

    private string GetWordString()
    {

        if (_isHidden)
        {
            string newString = "";
            foreach (char c in _word)
            {
                newString += "_";
            }
            return newString;
        }

        return _word;
    }
    public void DisplayWord()
    {
        Console.Write(LocalGetWordString());
    }

    public String LocalGetWordString()
    {
        return GetWordString();
    }
}