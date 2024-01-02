namespace WordleClone.WordSet;

public class ArrayWithLoop : IWordSet
{
    private string[] _wordsArray;

    public void Add(string[] words) => _wordsArray = words;
    
    public bool Exists(string word) 
    {
        foreach(var currentWord in _wordsArray) {
            if(currentWord == word) {
                return true;
            }
        }
        return false;
    }
}