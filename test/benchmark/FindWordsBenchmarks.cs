using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using WordleClone.WordSet;

namespace WordleClone.Benchmark;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class FindWordsBenchmarks : BenchmarkTestBase
{
    [Params("abbey", "labor", "zebra")]
    public string ExistingWord;

    public FindWordsBenchmarks() : base(){}

    [Benchmark]
    public void FindExistingWord_With_ArrayWithBinarySearch() => ArrayWithBinarySearch.Exists(ExistingWord);

    [Benchmark]
    public void FindExistingWord_With_WordsArrayWithLinq() => WordsArrayWithLinq.Exists(ExistingWord);

    [Benchmark]
    public void FindExistingWord_With_ArrayWithLoop() => ArrayWithLoop.Exists(ExistingWord);

    [Benchmark]
    public void FindExistingWord_With_HashSet() => HashSet.Exists(ExistingWord);

    [Benchmark]
    public void FindExistingWord_With_TrieTree() => WordsArrayWithLinq.Exists(ExistingWord);
}