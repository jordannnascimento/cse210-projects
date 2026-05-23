// The Word class represents a single word in the scripture.
// Each word knows its own text and whether it is hidden.

public class Word
{
    // The text of the word, for example "Trust".
    private string _text;

    // True if the word is hidden, false if it is visible.
    private bool _isHidden;

    // Constructor: runs when a new Word is created.
    // The word starts visible (not hidden).
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Hide this word.
    public void Hide()
    {
        _isHidden = true;
    }

    // Show this word again.
    public void Show()
    {
        _isHidden = false;
    }

    // Returns true if the word is currently hidden.
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Returns what to show on screen.
    // If hidden, returns underscores. If not, returns the word.
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Make underscores the same length as the word.
            return new string('_', _text.Length);
        }
        return _text;
    }
}