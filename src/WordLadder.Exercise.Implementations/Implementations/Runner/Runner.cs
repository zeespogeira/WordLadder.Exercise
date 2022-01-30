using System.Threading.Tasks;

namespace WordLadder.Exercise.Implementations.Implementations.Runner
{
    public class Runner : IRunner
    {
        private readonly IWordLadderStrategy _wordLadderStrategy;
        private readonly IRunResultService _runResultService;
        private readonly IUIService _uiService;
        private readonly ILoadWordsService _loadWordsService;
        private readonly ILogger<Runner> _logger;

        public Runner(IWordLadderStrategy wordLadderStrategy, 
            IRunResultService runResultService,
            IUIService uiService,
            ILoadWordsService loadWordsService, 
            ILogger<Runner> logger)
        {
            _wordLadderStrategy = wordLadderStrategy;
            _runResultService = runResultService;
            _uiService = uiService;
            _loadWordsService = loadWordsService;
            _logger = logger;
        }

        public async Task RunAsync()
        {
            _logger.LogInformation($"Starting new run at ");

            _uiService.DisplayIntro();

            var wordFilePath = _uiService.AskWordFilePath();

            var words = await _loadWordsService.LoadAllFileLinesAsync(wordFilePath);

            var startWord = _uiService.AskStartWord();

            var endWord = _uiService.AskEndWord(words);

            var resultFileName = _uiService.AskResultFileName();

            _uiService.Summary();

            _logger.LogInformation($"Executting wordladder strategy");

            var strategyResponse = _wordLadderStrategy.FindShortestLadders(startWord, endWord, words);

            _runResultService.HandleResult(strategyResponse, resultFileName);

            _uiService.DisplaySuccessRunResult(strategyResponse, resultFileName);
        }
    }
}
