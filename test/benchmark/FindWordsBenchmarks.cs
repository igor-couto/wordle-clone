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
    private readonly string _existingWord;

    public FindWordsBenchmarks() : base(){}

    [Benchmark]
    public void FindExistingWord_With_ArrayWithBinarySearch() => ArrayWithBinarySearch.Exists(_existingWord);

    [Benchmark]
    public void FindExistingWord_With_WordsArrayWithLinq() => WordsArrayWithLinq.Exists(_existingWord);

    [Benchmark]
    public void FindExistingWord_With_ArrayWithLoop() => ArrayWithLoop.Exists(_existingWord);

    [Benchmark]
    public void FindExistingWord_With_HashSet() => HashSet.Exists(_existingWord);

    [Benchmark]
    public void FindExistingWord_With_TrieTree() => WordsArrayWithLinq.Exists(_existingWord);
}