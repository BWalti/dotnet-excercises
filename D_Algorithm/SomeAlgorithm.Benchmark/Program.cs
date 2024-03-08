using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using SomeAlgorithm;

BenchmarkRunner.Run<MinMaxBenchy>();
Console.WriteLine("Finished!");

public class MinMaxBenchy
{
    private const int N = 100_000;
    private readonly IEnumerable<int> numbers;

    public MinMaxBenchy()
    {
        var rnd = new Random(42);
        numbers = Enumerable.Range(0, N).Select(_ => rnd.Next()).ToArray();
    }
    
    [Benchmark]
    public (int smallest, int largest) Normal() => NumberUtilities.GetSmallestAndLargest(numbers);
    
    [Benchmark]
    public (int smallest, int largest) Improved() => NumberUtilities.GetSmallestAndLargestImproved(numbers);
}