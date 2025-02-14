using BenchmarkDotNet.Attributes;

namespace LINQTutorial;

[MemoryDiagnoser(false)]
public class PlinqBenchmark
{
    private static readonly Random random = new(80085);

    [Params(100, 100_000, 1_000_000)]
    public int Size { get; set; }

    private List<int>? _items;

    [GlobalSetup]
    public void Setup()
    {
        _items = [.. Enumerable.Range(1, Size).Select(x => random.Next())];
    }

    [Benchmark]
    public void Normal_Linq()
    {
        var result = _items.Where(x => x % 2 == 0).Select(x => x * 2).ToList();
    }

    [Benchmark]
    public void Parallel_Linq()
    {
        var result = _items.AsParallel().Where(x => x % 2 == 0).Select(x => x * 2).ToList();
    }


}