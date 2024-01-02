
BenchmarkDotNet v0.13.11, Windows 10 (10.0.19045.3803/22H2/2022Update)
Intel Core i5-7300HQ CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


 Method                                      | Mean           | Error        | StdDev        | Rank | Allocated |
-------------------------------------------- |---------------:|-------------:|--------------:|-----:|----------:|
 FindNonExistingWord_With_TrieTree           |       134.5 ns |      2.68 ns |       3.20 ns |    1 |         - |
 FindNonExistingWord_With_WordsArrayWithLinq | 2,143,952.2 ns | 86,750.92 ns | 255,787.04 ns |    2 |       1 B |
