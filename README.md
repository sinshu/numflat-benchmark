```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3737/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700K, 1 CPU, 20 logical and 12 physical cores
.NET SDK 8.0.205
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2


```
| Method                     | Mean        | Error     | StdDev    | Allocated |
|--------------------------- |------------:|----------:|----------:|----------:|
| ArrayForLoopSum            |  2,742.6 ns |  15.18 ns |  14.20 ns |         - |
| ArrayIEnumerableForeachSum |  5,462.1 ns |  32.11 ns |  30.04 ns |      32 B |
| ArrayLinqSum               |    561.5 ns |   3.31 ns |   3.09 ns |         - |
| VectorForLoopSum           | 11,229.6 ns | 124.79 ns | 116.73 ns |         - |
| VectorForeachSum           |  2,694.6 ns |  25.87 ns |  24.20 ns |         - |
| VectorUnsafeForLoopSum     |  3,380.1 ns |  23.02 ns |  21.53 ns |         - |
| VectorLinqSum              |  7,232.8 ns |  39.97 ns |  37.39 ns |      80 B |
