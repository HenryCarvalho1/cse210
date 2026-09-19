using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        string[] allWords = text.Split(' ');

        foreach (string wordText in allWords)
        {
            Word newWord = new Word(wordText);
            _words.Add(newWord);
        }
    }

    public string GetDisplayText()
    {
        string displayText = $"{_reference.GetDisplayText()} ";

        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        return displayText;
    }

    public void HideRandomWords(int numberToHide)
{
    Random random = new Random();

    for (int i = 0; i < numberToHide; i++)
    {
        List<Word> visibleWords = new List<Word>();
        
        foreach (Word word in _words)
        {
            if (!word.IsHidden()) 
            {
                visibleWords.Add(word);
            }
        }

        if (visibleWords.Count == 0)
        {
            break;
        }

        int randomIndex = random.Next(0, visibleWords.Count);

        visibleWords[randomIndex].Hide();
    }
}
    public bool IsCompletelyHidden()
{
    foreach (Word word in _words)
    {
        if (word.IsHidden() == false)
        {
            return false;
        }
    }

    return true;
}

}
