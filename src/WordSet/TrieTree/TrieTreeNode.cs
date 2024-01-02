namespace WordleClone.WordSet;

public class TrieTreeNode
{
    private static readonly int AlphabetSize = 26;

    public TrieTreeNode[] Children { get; private set; }
    public bool IsWord { get; set; }

    public TrieTreeNode GetChild(char ch)
    {
        if (Children == null)
            Children = new TrieTreeNode[AlphabetSize];

        var index = ch - 'a';
        if (Children[index] == null)
            Children[index] = new TrieTreeNode();
        
        return Children[index];
    }
}