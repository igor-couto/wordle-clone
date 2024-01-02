
BenchmarkDotNet v0.13.11, Windows 10 (10.0.19045.3803/22H2/2022Update)
Intel Core i5-7300HQ CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


 Method                                   | Mean          | Error         | StdDev         | Median        | Rank | Allocated |
----------------------------------------- |--------------:|--------------:|---------------:|--------------:|-----:|----------:|
 FindExistingWord_With_WordsArrayWithLinq |      52.33 ns |      0.456 ns |       0.381 ns |      52.37 ns |    1 |         - |
 FindExistingWord_With_TrieTree           | 919,201.32 ns | 45,106.761 ns | 132,998.302 ns | 881,151.03 ns |    2 |         - |
