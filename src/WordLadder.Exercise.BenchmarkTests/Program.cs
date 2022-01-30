using System;

namespace WordLadder.Exercise.BenchmarkTests
{
    /// <summary>
    /// on the project folder run: dotnet run -c Release
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            Console.WriteLine("In order to run Benchmark make sure the project runs in RELEASE mode");
#endif

#if RELEASE
            var summary = BenchmarkRunner.Run<WordLadderRunnerBenchmarkTest>();
#endif
        }
    }
}
