```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19045.3324/22H2/2022Update)
Intel Core i7-9750HF CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.306
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2


```
| Method                     | Mean         | Error     | StdDev    | Ratio    | RatioSD | Rank | Gen0    | Allocated | Alloc Ratio |
|--------------------------- |-------------:|----------:|----------:|---------:|--------:|-----:|--------:|----------:|------------:|
| CreateItemsTheClassicalWay |     942.6 ns |  11.73 ns |   9.79 ns | baseline |         |    1 |  1.0185 |   6.24 KB |             |
| CreateItemsWithActivator   | 153,863.3 ns | 976.29 ns | 865.45 ns | +16,222% |    1.2% |    2 | 10.0098 |  62.61 KB |       +903% |
