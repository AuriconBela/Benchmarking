```

BenchmarkDotNet v0.13.8, Windows 10 (10.0.19044.3324/21H2/November2021Update)
12th Gen Intel Core i5-1245U, 1 CPU, 12 logical and 10 physical cores
.NET SDK 7.0.304
  [Host]     : .NET 7.0.7 (7.0.723.27404), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.7 (7.0.723.27404), X64 RyuJIT AVX2


```
| Method                       | Mean         | Error       | StdDev      | Median       | Ratio    | RatioSD | Rank | Gen0    | Allocated | Alloc Ratio |
|----------------------------- |-------------:|------------:|------------:|-------------:|---------:|--------:|-----:|--------:|----------:|------------:|
| CreateItemsTheClassicalWay   |     754.3 ns |    13.75 ns |    11.48 ns |     757.7 ns | baseline |         |    1 |  1.0223 |   6.27 KB |             |
| CreateItemsWithActivatorGood |   1,154.6 ns |    31.06 ns |    89.12 ns |   1,124.0 ns |     +57% |    9.3% |    2 |  1.0166 |   6.24 KB |         -0% |
| CreateItemsWithActivatorBad  | 121,478.1 ns | 2,646.46 ns | 7,507.56 ns | 119,207.0 ns | +15,776% |    5.1% |    3 | 10.1318 |  62.68 KB |       +900% |
