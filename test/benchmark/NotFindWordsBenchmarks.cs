using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using WordleClone.WordSet;

namespace WordleClone.Benchmark;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class NotFindWordsBenchmarks : BenchmarkTestBase
{
    private readonly string _nonExistingWord = "nonexistingword";

    public NotFindWordsBenchmarks() : base(){}

    [Benchmark]
    public void FindNonExistingWord_With_ArrayWithBinarySearch() => ArrayWithBinarySearch.Exists(_nonExistingWord);

    [Benchmark]
    public void FindNonExistingWord_With_WordsArrayWithLinq() => WordsArrayWithLinq.Exists(_nonExistingWord);

    [Benchmark]
    public void FindNonExistingWord_With_ArrayWithLoop() => ArrayWithLoop.Exists(_nonExistingWord);

    [Benchmark]
    public void FindNonExistingWord_With_HashSet() => HashSet.Exists(_nonExistingWord);

    [Benchmark]
    public void FindNonExistingWord_With_TrieTree() => TrieTree.Exists(_nonExistingWord);
}