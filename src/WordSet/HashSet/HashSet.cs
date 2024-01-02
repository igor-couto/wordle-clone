namespace WordleClone.WordSet;

public class HashSet : IWordSet
{
    private HashSet<string> _wordsHashSet;

    public void Add(string[] words) => _wordsHashSet = new HashSet<string>(words);
    
    public bool Exists(string word) => _wordsHashSet.Contains(word);
}