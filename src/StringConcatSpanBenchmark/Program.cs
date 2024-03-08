using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using StringConcatSpanBenchmark;

var options = DefaultConfig.Instance.WithSummaryStyle(
    summaryStyle: SummaryStyle.Default.WithRatioStyle(RatioStyle.Trend));

_ = BenchmarkRunner.Run<BenchmarkStringConcat>(options);
