using System;
using System.Threading.Tasks;
using WordLadder.Exercise.Contracts.Interfaces;

namespace WordLadder.Exercise.Implementations.Runner
{
    public class Runner : IRunner
    {
        private readonly IWordLadderStrategy _wordLadderStrategy;
        private readonly IRunResultService _runResultService;
        private readonly IUIService _uiService;
        private readonly ILoadWordsService _loadWordsService;
        private readonly ILogService _logService;

        public Runner(IWordLadderStrategy wordLadderStrategy, 
            IRunResultService runResultService,
            IUIService uiService,
            ILoadWordsService loadWordsService, 
            ILogService logService)
        {
            _wordLadderStrategy = wordLadderStrategy;
            _runResultService = runResultService;
            _uiService = uiService;
            _loadWordsService = loadWordsService;
            _logService = logService;
        }

        public async Task RunAsync()
        {
            try
            {
                _logService.LogInfo($"Starting new run at ");

                _uiService.DisplayIntro();

                var wordFilePath = _uiService.AskWordFilePath();

                var words = await _loadWordsService.LoadAllFileLinesAsync(wordFilePath);

                var startWord = _uiService.AskStartWord();

                var endWord = _uiService.AskEndWord(words);

                var resultFileName = _uiService.AskResultFileName();

                _uiService.Summary();

                _logService.LogInfo($"Executting wordladder strategy");

                var strategyResponse = _wordLadderStrategy.FindShortestLadders(startWord, endWord, words);

                _runResultService.HandleResult(strategyResponse, resultFileName);

                _uiService.DisplaySuccessRunResult(strategyResponse, resultFileName);
            }
            catch (Exception e)
            {
                _logService.LogError(e, "Exception in Runner.RunAsync");
            }

            _uiService.FinishRun();
        }
    }
}
