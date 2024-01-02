using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using WordleClone.WordSet;

namespace WordleClone.Benchmark;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class NotFindWordsBenchmarks
{
    public TrieTree TrieTree { get; set; } = new();
    public WordsArrayWithLinq WordsArrayWithLinq { get; set; } = new();

    public NotFindWordsBenchmarks()
    {
        var words = File.ReadAllLines("./Resources/words.txt");

        WordsArrayWithLinq.Add(words);
        TrieTree.Add(words);
    }

    [Benchmark]
    public void FindNonExistingWord_With_WordsArrayWithLinq() => WordsArrayWithLinq.Exists("nonexistingword");

    [Benchmark]
    public void FindNonExistingWord_With_TrieTree() => TrieTree.Exists("nonexistingword");
}