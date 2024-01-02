namespace WordleClone.WordSet;

public class TrieTree : IWordSet
{
    private readonly TrieTreeNode _root;

    public TrieTree() => _root = new TrieTreeNode();

    public void Add(string[] words)
    {
        foreach (var word in words)
            Add(word);
    }

    private void Add(string word)
    {
        var current = _root;
        foreach (var character in word)
            current = current.GetChild(character);
        
        current.IsWord = true;
    }

    public bool Exists(string word)
    {
        var current = _root;
        foreach (var character in word)
        {
            var index = character - 'a';
            if (current.Children == null || current.Children[index] == null)
                return false;
            
            current = current.Children[index];
        }
        return current != null && current.IsWord;
    }
}