using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using WordleClone.WordSet;

namespace WordleClone.Benchmark;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class FindWordsBenchmarks
{

    public TrieTree TrieTree { get; set; } = new();
    public WordsArrayWithLinq WordsArrayWithLinq { get; set; } = new();

    public FindWordsBenchmarks()
    {
        var words = File.ReadAllLines("./Resources/words.txt");

        WordsArrayWithLinq.Add(words);
        TrieTree.Add(words);
    }

    [Benchmark]
    public void FindExistingWord_With_WordsArrayWithLinq() => TrieTree.Exists("labor");

    [Benchmark]
    public void FindExistingWord_With_TrieTree() => WordsArrayWithLinq.Exists("labor");
}