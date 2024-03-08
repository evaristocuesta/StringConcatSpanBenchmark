using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;

namespace StringConcatSpanBenchmark;

[MemoryDiagnoser(displayGenColumns: true)]
public class BenchmarkStringConcat
{
    private const string _text = "Lorem Ipsum is simply dummy test";

    [Benchmark]
    public string MethodSubstring()
    {
        return _text.Substring(10) + "---" + _text.Substring(0, 5);
    }

    [Benchmark]
    public string MethodInterpolateSubstring()
    {
        return $"{_text.Substring(10)}---{_text.Substring(0, 5)}";
    }

    [Benchmark]
    public string MethodConcatSubstring()
    {
        return string.Concat(_text.Substring(10), "---", _text.Substring(0, 5));
    }

    [Benchmark(Baseline = true)]
    public string MethodConcatAsSpan()
    {
        return string.Concat(_text.AsSpan(10), "---", _text.AsSpan(0, 5));
    }
}