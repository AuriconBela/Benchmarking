using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using SampleApp.Model;

namespace SampleApp.Benchmarking;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
[Config(typeof(Config))]
public class CreationBenchmarks
{
    private readonly List<Tuple<int,string, Type, Type>> _whatToCreate = new();
    private const int _numberOfItems = 100;

    public CreationBenchmarks()
    {
        CalcWhatToCreate();
    }
    [Benchmark(Baseline = true)]
    public void CreateItemsTheClassicalWay()
    {
        foreach (var item in _whatToCreate)
        {
            IGepeszetElem elem = item.Item1 switch 
            {
                0 => new Futes(),
                1 => new Hutes(),
                2 => new HasznalatiMelegViz(),
                3 => new Szellozes(),
                4 => new Vilagitas(),
                5 => new Napelem(),
                6 => new NapKollektor(),
                7 => new EgyebMegujulo(),
                _ => throw new NotImplementedException()
            };
        }
    }

    [Benchmark]
    public void CreateItemsWithActivatorGood()
    {
        foreach (var item in _whatToCreate)
        {
            var elem = Activator.CreateInstance(item.Item4) as IGepeszetElem;
        }
    }    
    
    [Benchmark]
    public void CreateItemsWithActivatorBad()
    {
        foreach (var item in _whatToCreate)
        {
            var type = item.Item3.Assembly
            .GetTypes()
            .Single(t => t.Name == item.Item2);

            var elem = Activator.CreateInstance(type) as IGepeszetElem;
        }
    }

    private static string IdToName(int id)
    {
        return id switch 
        {
            0 => "Futes",
            1 => "Hutes",
            2 => "HasznalatiMelegViz",
            3 => "Szellozes",
            4 => "Vilagitas",
            5 => "Napelem",
            6 => "NapKollektor",
            7 => "EgyebMegujulo",
            _ => throw new NotImplementedException()
        };
    }

    private static Type IdToType1(int id)
    {
        return id switch 
        {
            0 => typeof(IFutes),
            1 => typeof(IHutes),
            2 => typeof(IHasznalatiMelegViz),
            3 => typeof(ISzellozes),
            4 => typeof(IVilagitas),
            5 => typeof(INapelem),
            6 => typeof(INapKollektor),
            7 => typeof(IEgyebMegujulo),
            _ => throw new NotImplementedException()
        };
    }    
    
    private static Type IdToType2(int id)
    {
        return id switch 
        {
            0 => typeof(IFutes).Assembly.GetTypes().Single(t => t.Name == "Futes"),
            1 => typeof(IHutes).Assembly.GetTypes().Single(t => t.Name == "Hutes"),
            2 => typeof(IHasznalatiMelegViz).Assembly.GetTypes().Single(t => t.Name == "HasznalatiMelegViz"),
            3 => typeof(ISzellozes).Assembly.GetTypes().Single(t => t.Name == "Szellozes"),
            4 => typeof(IVilagitas).Assembly.GetTypes().Single(t => t.Name == "Vilagitas"),
            5 => typeof(INapelem).Assembly.GetTypes().Single(t => t.Name == "Napelem"),
            6 => typeof(INapKollektor).Assembly.GetTypes().Single(t => t.Name == "NapKollektor"),
            7 => typeof(IEgyebMegujulo).Assembly.GetTypes().Single(t => t.Name == "EgyebMegujulo"),
            _ => throw new NotImplementedException()
        };
    }

    private void CalcWhatToCreate()
    {
        var rnd = new Random();
        for (int i = 0; i < _numberOfItems; i++)
        {
            var id = rnd.Next(8);
            _whatToCreate.Add(new(id,IdToName(id),IdToType1(id), IdToType2(id)));
        }
    }

    private class Config : ManualConfig
    {
        public Config()
        {
            SummaryStyle = SummaryStyle.Default.WithRatioStyle(RatioStyle.Percentage);
        }
    }
}
