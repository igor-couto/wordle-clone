namespace WordleClone.WordSet;

public class TrieTreeNode(char value)
{
    public char Value { get; set; } = value;
    public Dictionary<char, TrieTreeNode> Children { get; set; } = [];
    public bool IsWord { get; set; } = false;
}