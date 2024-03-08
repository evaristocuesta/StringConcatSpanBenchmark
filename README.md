# StringConcatSpanBenchmark

Benchmark to compare Substring function versus AsSpan function concatenating strings. 

```csharp
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
```


| Method                     | Mean     | Error    | StdDev   | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|--------------------------- |---------:|---------:|---------:|-------------:|--------:|-------:|----------:|------------:|
| MethodSubstring            | 16.85 ns | 0.129 ns | 0.121 ns | 1.60x slower |   0.02x | 0.0184 |     192 B |  2.18x more |
| MethodInterpolateSubstring | 16.86 ns | 0.115 ns | 0.102 ns | 1.60x slower |   0.02x | 0.0184 |     192 B |  2.18x more |
| MethodConcatSubstring      | 16.16 ns | 0.086 ns | 0.081 ns | 1.53x slower |   0.01x | 0.0184 |     192 B |  2.18x more |
| MethodConcatAsSpan         | 10.56 ns | 0.069 ns | 0.065 ns |     baseline |         | 0.0084 |      88 B |             |