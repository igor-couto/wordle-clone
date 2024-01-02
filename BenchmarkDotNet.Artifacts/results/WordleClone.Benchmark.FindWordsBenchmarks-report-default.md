
BenchmarkDotNet v0.13.11, Windows 10 (10.0.19045.3803/22H2/2022Update)
Intel Core i5-7300HQ CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


 Method                                      | Mean          | Error         | StdDev         | Median        | Rank | Allocated |
-------------------------------------------- |--------------:|--------------:|---------------:|--------------:|-----:|----------:|
 FindExistingWord_With_HashSet               |      15.96 ns |      0.358 ns |       0.427 ns |      15.95 ns |    1 |         - |
 FindExistingWord_With_ArrayWithBinarySearch |   1,135.48 ns |     15.251 ns |      14.266 ns |   1,139.03 ns |    2 |         - |
 FindExistingWord_With_ArrayWithLoop         | 878,678.05 ns | 46,347.708 ns | 133,723.736 ns | 869,854.44 ns |    3 |         - |
 FindExistingWord_With_WordsArrayWithLinq    | 946,705.39 ns | 18,889.931 ns |  33,576.833 ns | 949,154.93 ns |    4 |         - |
 FindExistingWord_With_TrieTree              | 948,711.21 ns | 16,894.213 ns |  46,813.783 ns | 927,505.66 ns |    4 |       1 B |
