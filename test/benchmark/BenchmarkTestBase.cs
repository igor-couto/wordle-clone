using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using WordleClone.WordSet;

namespace WordleClone.Benchmark;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public abstract class BenchmarkTestBase
{
    public ArrayWithBinarySearch ArrayWithBinarySearch { get; set; } = new();
    public WordsArrayWithLinq WordsArrayWithLinq { get; set; } = new();
    public ArrayWithLoop ArrayWithLoop { get; set; } = new();
    public HashSet HashSet { get; set; } = new();
    public TrieTree TrieTree { get; set; } = new();

    public BenchmarkTestBase()
    {
        var words = File.ReadAllLines("./Resources/words.txt");

        ArrayWithBinarySearch.Add(words);
        ArrayWithLoop.Add(words);
        HashSet.Add(words);
        WordsArrayWithLinq.Add(words);
        TrieTree.Add(words);
    }
}