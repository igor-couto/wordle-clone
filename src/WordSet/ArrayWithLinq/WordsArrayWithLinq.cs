namespace WordleClone.WordSet;

public class WordsArrayWithLinq : IWordSet
{
    private string[] _wordsArray;

    public void Add(string[] words) => _wordsArray = words;
    
    public bool Exists(string word) => _wordsArray.Contains(word);
}