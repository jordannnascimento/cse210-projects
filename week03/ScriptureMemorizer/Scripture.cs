using System;
using System.Collections.Generic;

// The Scripture class holds the reference and all the words.
// It can hide words and build the full text to display.

public class Scripture
{
    // The reference of this scripture.
    private Reference _reference;

    // The list of all words in the scripture.
    private List<Word> _words;

    // Used to pick random words to hide.
    private Random _random;

    // Constructor: takes the reference and the scripture text.
    // It splits the text into words and stores each one as a Word.
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        // Split the text by spaces, one word at a time.
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    // Hides a few random words that are not hidden yet.
    public void HideRandomWords(int numberToHide)
    {
        // Get only the words that are still visible.
        List<Word> visibleWords = _words.FindAll(word => !word.IsHidden());

        // Hide up to numberToHide words.
        int count = Math.Min(numberToHide, visibleWords.Count);
        for (int i = 0; i < count; i++)
        {
            // Pick a random visible word and hide it.
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    // Builds the full scripture text to show on screen.
    public string GetDisplayText()
    {
        // Start with the reference.
        string result = _reference.GetDisplayText() + "\n";

        // Add each word's display text.
        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }
        return result;
    }

    // Returns true when every word is hidden.
    public bool IsCompletelyHidden()
    {
        return _words.TrueForAll(word => word.IsHidden());
    }
}