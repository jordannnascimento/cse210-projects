// The Reference class holds the location of the scripture.
// For example "John 3:16" or "Proverbs 3:5-6".

public class Reference
{
    // The book name, for example "John".
    private string _book;

    // The chapter number.
    private int _chapter;

    // The first verse number.
    private int _startVerse;

    // The last verse number 
    private int _endVerse;

    // Constructor for a single verse, like "John 3:16".
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    // Constructor for a verse range, like "Proverbs 3:5-6".
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // Builds the reference as a text string.
    public string GetDisplayText()
    {
        if (_startVerse == _endVerse)
        {
            // Only one verse.
            return $"{_book} {_chapter}:{_startVerse}";
        }
        // A range of verses.
        return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}