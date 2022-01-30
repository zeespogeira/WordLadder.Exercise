using System.Linq;
using NUnit.Framework;
using WordLadder.Exercise.Implementations.Services;

namespace WordLadder.Exercise.UnitTests.Services
{
    public class WordSetSanitizerServiceTests
    {
        [Test]
        public void Test_WordSanitation_should_perform_as_expected()
        {
            //arrange
            var sut = new WordSetSanitizerService();
            var words = new[] { " trim ", "word", " word", "bigword" };
            var expectedWords = new[] { "trim", "word" };
            
            //act
            var result = sut.Sanitize(words);

            //assert
            Assert.IsTrue(expectedWords.SequenceEqual(result));
        }
    }
}
