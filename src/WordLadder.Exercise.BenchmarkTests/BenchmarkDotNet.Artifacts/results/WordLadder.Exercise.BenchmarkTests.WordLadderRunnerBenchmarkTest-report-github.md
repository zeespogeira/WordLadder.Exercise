``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1466 (21H1/May2021Update)
Intel Core i7-6700HQ CPU 2.60GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.404
  [Host]     : .NET 5.0.13 (5.0.1321.56516), X64 RyuJIT
  DefaultJob : .NET 5.0.13 (5.0.1321.56516), X64 RyuJIT


```
|                              Method |       Mean |     Error |     StdDev |      Gen 0 |     Gen 1 |     Gen 2 | Allocated |
|------------------------------------ |-----------:|----------:|-----------:|-----------:|----------:|----------:|----------:|
| FindLadders_with_WordLadderRunnerV1 | 269.024 ms | 5.8659 ms | 16.4486 ms | 12000.0000 | 5000.0000 | 2000.0000 |     79 MB |
| FindLadders_with_WordLadderRunnerV2 |   4.525 ms | 0.1081 ms |  0.3187 ms |   375.0000 |  367.1875 |  367.1875 |      2 MB |
