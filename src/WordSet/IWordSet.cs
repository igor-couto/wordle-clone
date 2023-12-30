namespace WordleClone.WordSet;

public interface IWordSet
{
    public void Add(string[] words);
    public bool Exists(string word);
}