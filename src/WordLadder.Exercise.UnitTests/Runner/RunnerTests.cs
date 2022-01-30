using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WordLadder.Exercise.Contracts.Interfaces;
using WordLadder.Exercise.Contracts.ResponseObjs;

namespace WordLadder.Exercise.UnitTests.Runner
{
    public class RunnerTests
    {
        [Test]
        public async Task Test_Runner_success_run_should_execute_expected_sequence_of_steps()
        {
            //arrange
            const string startWord = "startWord";
            const string endWord = "endWord";
            const string resultFileName = "resultFileName";
            const string wordFilePath = "wordFilePath";
            var words = new HashSet<string>();
            var ladderResponse = new WordLadderStrategyResponse(new List<string> { "a" });

            var loggerMock = new Mock<ILogService>();

            var wordLadderStrategyMock = new Mock<IWordLadderStrategy>();
            wordLadderStrategyMock.Setup(x => x.FindShortestLadders(startWord, endWord, words))
                                .Returns(ladderResponse);

            var runResultServiceMock = new Mock<IRunResultService>();

            var loadFileServiceMock = new Mock<ILoadWordsService>();
            loadFileServiceMock.Setup(x => x.LoadAllFileLinesAsync(wordFilePath))
                                .ReturnsAsync(() => words);

            var uiServiceMock = new Mock<IUIService>();
            uiServiceMock.Setup(x => x.AskStartWord()).Returns(startWord);
            uiServiceMock.Setup(x => x.AskEndWord(words)).Returns(endWord);
            uiServiceMock.Setup(x => x.AskWordFilePath()).Returns(wordFilePath);
            uiServiceMock.Setup(x => x.AskResultFileName()).Returns(resultFileName);

            var sut = new Implementations.Runner.Runner(wordLadderStrategyMock.Object,
                                                        runResultServiceMock.Object,
                                                        uiServiceMock.Object,
                                                        loadFileServiceMock.Object,
                                                        loggerMock.Object);

            //act
            await sut.RunAsync();

            //assert
            uiServiceMock.Verify(x => x.DisplayIntro(), Times.Once);
            uiServiceMock.Verify(x => x.AskStartWord(), Times.Once);
            uiServiceMock.Verify(x => x.AskEndWord(words), Times.Once);
            uiServiceMock.Verify(x => x.AskWordFilePath(), Times.Once);
            uiServiceMock.Verify(x => x.AskResultFileName(), Times.Once);
            uiServiceMock.Verify(x => x.DisplaySuccessRunResult(ladderResponse, resultFileName), Times.Once);
            loadFileServiceMock.Verify(x => x.LoadAllFileLinesAsync(wordFilePath), Times.Once);
            wordLadderStrategyMock.Verify(x => x.FindShortestLadders(startWord, endWord, words), Times.Once);
            runResultServiceMock.Verify(x=>x.HandleResult(ladderResponse, resultFileName), Times.Once);
            loggerMock.Verify(x=>x.LogError(It.IsAny<Exception>(), It.IsAny<string>()), Times.Never, "succeess run should not log errors");
            loggerMock.Verify(x => x.LogInfo(It.IsAny<string>()), Times.AtLeastOnce, "Should log some info messages");
        }

        [Test]
        public async Task Test_Runner_run_with_exceptions_should_log_errors()
        {
            //arrange
            var exception = new Exception();
            var ladderResponse = new WordLadderStrategyResponse(new List<string> { "a" });

            var loggerMock = new Mock<ILogService>();

            var wordLadderStrategyMock = new Mock<IWordLadderStrategy>();
            wordLadderStrategyMock.Setup(x => x.FindShortestLadders(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<HashSet<string>>()))
                                .Returns(ladderResponse);

            var runResultServiceMock = new Mock<IRunResultService>();

            var loadFileServiceMock = new Mock<ILoadWordsService>();
            loadFileServiceMock.Setup(x => x.LoadAllFileLinesAsync(It.IsAny<string>()))
                                .Throws(exception);

            var uiServiceMock = new Mock<IUIService>();

            var sut = new Implementations.Runner.Runner(wordLadderStrategyMock.Object,
                                                        runResultServiceMock.Object,
                                                        uiServiceMock.Object,
                                                        loadFileServiceMock.Object,
                                                        loggerMock.Object);

            //act
            await sut.RunAsync();

            //assert
            loggerMock.Verify(x => x.LogError(exception, It.IsAny<string>()), Times.Once, "should not log errors");
        }
    }
}
