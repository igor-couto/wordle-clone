namespace WordleClone.WordSet;

public class ArrayWithBinarySearch : IWordSet
{
    private string[] _wordsArray;

    public void Add(string[] words) => _wordsArray = words;
    
    public bool Exists(string word) => Array.BinarySearch(_wordsArray, word) >= 0;
}