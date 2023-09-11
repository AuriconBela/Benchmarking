using BenchmarkDotNet.Running;
using SampleApp.Benchmarking;

namespace Benchmarking;

public class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<CreationBenchmarks>();
    }
}