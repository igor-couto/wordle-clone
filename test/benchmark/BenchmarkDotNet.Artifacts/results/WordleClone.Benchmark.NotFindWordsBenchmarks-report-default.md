
BenchmarkDotNet v0.13.11, Windows 10 (10.0.19045.3803/22H2/2022Update)
Intel Core i5-7300HQ CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


 Method                                         | Mean          | Error       | StdDev      | Rank | Allocated |
----------------------------------------------- |--------------:|------------:|------------:|-----:|----------:|
 FindNonExistingWord_With_TrieTree              |      8.025 ns |   0.0373 ns |   0.0330 ns |    1 |         - |
 FindNonExistingWord_With_HashSet               |      9.820 ns |   0.0717 ns |   0.0636 ns |    2 |         - |
 FindNonExistingWord_With_ArrayWithBinarySearch |    776.757 ns |   5.0414 ns |   4.7158 ns |    3 |         - |
 FindNonExistingWord_With_ArrayWithLoop         | 23,419.699 ns | 460.8425 ns | 630.8065 ns |    4 |         - |
 FindNonExistingWord_With_WordsArrayWithLinq    | 28,882.381 ns | 351.2523 ns | 328.5616 ns |    5 |         - |
