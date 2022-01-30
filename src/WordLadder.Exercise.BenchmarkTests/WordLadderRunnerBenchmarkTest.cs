using System.Collections.Generic;
using System.IO;
using System.Linq;
using BenchmarkDotNet.Attributes;
using WordLadder.Exercise.Implementations.WordLadderStrategies;

namespace WordLadder.Exercise.BenchmarkTests
{
    [MemoryDiagnoser]
    public class WordLadderRunnerBenchmarkTest
    {
        private string _startWord = "spin";
        private string _endWord = "spot";


        [Benchmark]
        public int FindLadders_with_WordLadderRunnerV1()
        {
            var sut = new WordLadderStrategyV1();

            var ladders = sut.FindLadders(_startWord, _endWord, GetWords());

            return ladders.Any() ? ladders.First().Count : 0;
        }

        [Benchmark]
        public int FindLadders_with_WordLadderRunnerV2()
        {
            var sut = new WordLadderStrategyV2();

            var ladders = sut.FindLadders(_startWord, _endWord, GetWords());

            return ladders.Any() ? ladders.First().Count : 0;
        }

        private HashSet<string> GetWords() => new HashSet<string>(File.ReadAllLines("words-english.txt"));
    }
}
