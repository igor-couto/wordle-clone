
BenchmarkDotNet v0.13.11, Windows 10 (10.0.19045.3803/22H2/2022Update)
Intel Core i5-7300HQ CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


 Method                                         | Mean            | Error         | StdDev         | Rank | Allocated |
----------------------------------------------- |----------------:|--------------:|---------------:|-----:|----------:|
 FindNonExistingWord_With_HashSet               |        11.77 ns |      0.277 ns |       0.559 ns |    1 |         - |
 FindNonExistingWord_With_TrieTree              |       115.78 ns |      1.312 ns |       1.227 ns |    2 |         - |
 FindNonExistingWord_With_ArrayWithBinarySearch |     1,267.09 ns |     17.284 ns |      16.168 ns |    3 |         - |
 FindNonExistingWord_With_ArrayWithLoop         | 1,998,761.61 ns | 75,439.063 ns | 222,433.780 ns |    4 |       2 B |
 FindNonExistingWord_With_WordsArrayWithLinq    | 2,155,137.19 ns | 42,488.478 ns |  37,664.929 ns |    5 |       2 B |
