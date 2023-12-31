using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using WordleClone.Benchmark;

var benchmarkConfiguration = ManualConfig.CreateEmpty()
    .AddColumnProvider(DefaultColumnProviders.Instance)
    .AddExporter(HtmlExporter.Default)
    .AddExporter(MarkdownExporter.Default)
    .AddLogger(ConsoleLogger.Default);

BenchmarkRunner.Run<FindWordsBenchmarks>(benchmarkConfiguration);