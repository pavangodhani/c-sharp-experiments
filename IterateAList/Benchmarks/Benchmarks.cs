using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    public static readonly Random Rng = new(80085);

    [Params(100, 100_000, 1_000_000)]
    public int Size { get; set; } = 100;

    public List<int> _items = new();

    [GlobalSetup]
    public void Setup()
    {
        _items = Enumerable.Range(1, Size).Select(_ => Rng.Next()).ToList();
    }

    [Benchmark]
    public void For()
    {
        for (int i = 0; i < Size; i++)
        {
            var item = _items[i];
        }
    }

    [Benchmark]
    public void For_Each()
    {
        foreach (var item in _items)
        {
            
        }
    }
}