
BenchmarkDotNet v0.13.11, Windows 10 (10.0.19045.3803/22H2/2022Update)
Intel Core i5-7300HQ CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


 Method                                      | ExistingWord | Mean         | Error      | StdDev     | Rank | Allocated |
-------------------------------------------- |------------- |-------------:|-----------:|-----------:|-----:|----------:|
 FindExistingWord_With_HashSet               | labor        |     13.60 ns |   0.121 ns |   0.113 ns |    1 |         - |
 FindExistingWord_With_HashSet               | zebra        |     14.21 ns |   0.088 ns |   0.078 ns |    2 |         - |
 FindExistingWord_With_HashSet               | abbey        |     21.11 ns |   0.162 ns |   0.151 ns |    3 |         - |
 FindExistingWord_With_ArrayWithLoop         | abbey        |    129.31 ns |   0.892 ns |   0.834 ns |    4 |         - |
 FindExistingWord_With_WordsArrayWithLinq    | abbey        |    168.34 ns |   1.364 ns |   1.209 ns |    5 |         - |
 FindExistingWord_With_TrieTree              | abbey        |    181.27 ns |   1.032 ns |   0.862 ns |    6 |         - |
 FindExistingWord_With_ArrayWithBinarySearch | labor        |    595.87 ns |   1.949 ns |   1.728 ns |    7 |         - |
 FindExistingWord_With_ArrayWithBinarySearch | zebra        |    620.26 ns |   2.584 ns |   2.290 ns |    8 |         - |
 FindExistingWord_With_ArrayWithBinarySearch | abbey        |    755.97 ns |   4.601 ns |   3.842 ns |    9 |         - |
 FindExistingWord_With_ArrayWithLoop         | labor        | 34,777.74 ns | 150.466 ns | 133.384 ns |   10 |         - |
 FindExistingWord_With_WordsArrayWithLinq    | labor        | 40,823.94 ns | 230.792 ns | 204.591 ns |   11 |         - |
 FindExistingWord_With_TrieTree              | labor        | 40,879.98 ns | 158.750 ns | 132.563 ns |   11 |         - |
 FindExistingWord_With_ArrayWithLoop         | zebra        | 67,688.30 ns | 373.886 ns | 312.212 ns |   12 |         - |
 FindExistingWord_With_WordsArrayWithLinq    | zebra        | 80,106.28 ns | 597.347 ns | 558.759 ns |   13 |         - |
 FindExistingWord_With_TrieTree              | zebra        | 97,959.77 ns | 649.768 ns | 607.794 ns |   14 |         - |
