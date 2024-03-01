```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3155/23H2/2023Update/SunValley3)
AMD Ryzen 5 3600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.100-preview.1.24101.2
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2


```
| Method       | Mean     | Error   | StdDev  | Ratio        | RatioSD |
|------------- |---------:|--------:|--------:|-------------:|--------:|
| IncludeAsync | 219.5 μs | 2.13 μs | 1.89 μs |     baseline |         |
| JoinAsync    | 212.3 μs | 3.52 μs | 3.12 μs | 1.03x faster |   0.01x |
