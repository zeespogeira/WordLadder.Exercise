using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using WordLadder.Exercise.Implementations.WordLadderStrategies;

namespace WordLadder.Exercise.UnitTests.WordLadderStrategies
{
    /// <summary>
    /// This class implements tests to make sure the algorithms run as expected.
    /// Test cases are provided by the GetTestCases and were collected from the web.
    /// </summary>
    public class WordLadderStrategiesTests
    {
        [TestCaseSource(nameof(GetTestCases))]
        public void Test_WordLadderRunnerV1_should_return_expected_result(string start, string end, HashSet<string> words, int expectedJumps)
        {
            //arrange
            var sut = new WordLadderStrategyV1();

            //act
            var response = sut.FindShortestLadders(start, end, words);

            //assert
            Assert.AreEqual(expectedJumps, response.NumberOfSteps);
        }


        [TestCaseSource(nameof(GetTestCases))]
        public void Test_WordLadderRunnerV2_should_return_expected_result(string start, string end, HashSet<string> words, int expectedJumps)
        {
            //arrange
            var sut = new WordLadderStrategyV2();

            //act
            var response = sut.FindShortestLadders(start, end, words);

            //assert
            Assert.AreEqual(expectedJumps, response.NumberOfSteps);
        }


        private static IEnumerable<TestCaseData> GetTestCases
        {
            get
            {
                yield return new TestCaseData("spin", "spot", new HashSet<string>(File.ReadAllLines("words-english.txt").ToList()), 3);
                yield return new TestCaseData("spin", "spot", new HashSet<string> { "spix", "spet", "spon", "spit", "sput", "span", "spat", "spot", "sean", "spoo" }, 3);
                yield return new TestCaseData("toon", "plea", new HashSet<string> { "poon", "plee", "same", "poie", "plie", "poin", "soin", "ponn", "plea" }, 7);
                yield return new TestCaseData("hit", "cog", new HashSet<string> { "hot", "dot", "dog", "lot", "log", "cog" }, 5);
            }
        }
    }

}
