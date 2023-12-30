namespace WordleClone.WordSet;

public class TrieTree : IWordSet
{
    private readonly TrieTreeNode _root;

    public TrieTree() => _root = new TrieTreeNode('*');

    public void Add(string[] words)
    {
        foreach (var word in words)
            Add(word);
    }

    private void Add(string word)
    {
        var current = _root;
        foreach (var character in word)
        {
            if (!current.Children.TryGetValue(character, out TrieTreeNode value))
            {
                value = new TrieTreeNode(character);
                current.Children[character] = value;
            }
            current = value;
        }
        current.IsWord = true;
    }

    public bool Exists(string word)
    {
        var current = _root;
        foreach (var character in word)
        {
            if (!current.Children.TryGetValue(character, out TrieTreeNode value))
            {
                return false;
            }
            current = value;
        }
        return current.IsWord;
    }
}