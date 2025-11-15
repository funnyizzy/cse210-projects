using System;

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            string hiddenString = "";
            for (int i = 0; i < _text.Length; i++)
            {
                hiddenString += "_";
            }

            return hiddenString;
        }

        return _text;
    }
}
