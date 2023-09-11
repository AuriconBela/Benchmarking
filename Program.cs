using BenchmarkDotNet.Running;
using SampleApp.Benchmarking;

namespace Benchmarking;

public class Program
{
    static void Main(string[] args)
    {
        var results = BenchmarkRunner.Run<CreationBenchmarks>();        
    }
}