```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3194)
Intel Core Ultra 7 155H, 1 CPU, 22 logical and 16 physical cores
.NET SDK 9.0.101
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2


```
| Method        | Size    | Mean           | Error        | StdDev       | Median         | Allocated |
|-------------- |-------- |---------------:|-------------:|-------------:|---------------:|----------:|
| **Normal_Linq**   | **100**     |       **224.7 ns** |      **4.17 ns** |      **3.48 ns** |       **224.2 ns** |     **800 B** |
| Parallel_Linq | 100     |    13,171.5 ns |    369.02 ns |  1,076.46 ns |    13,383.3 ns |   13976 B |
| **Normal_Linq**   | **100000**  |   **652,745.6 ns** | **13,045.21 ns** | **27,230.21 ns** |   **638,740.6 ns** |  **524858 B** |
| Parallel_Linq | 100000  |   589,144.6 ns | 10,006.83 ns |  9,828.04 ns |   587,178.3 ns | 1263478 B |
| **Normal_Linq**   | **1000000** | **5,620,357.7 ns** | **34,327.67 ns** | **30,430.58 ns** | **5,616,260.9 ns** | **4195209 B** |
| Parallel_Linq | 1000000 | 4,990,420.7 ns | 52,326.81 ns | 48,946.53 ns | 4,991,555.9 ns | 9982428 B |
