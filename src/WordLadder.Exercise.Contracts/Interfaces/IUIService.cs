using System.Collections.Generic;
using WordLadder.Exercise.Contracts.ResponseObjs;

namespace WordLadder.Exercise.Contracts.Interfaces
{
    public interface IUIService
    {
        void DisplayIntro();
        string AskWordFilePath();
        string AskStartWord();
        string AskEndWord(HashSet<string> words);
        string AskResultFileName();
        void Summary();
        void DisplaySuccessRunResult(WordLadderStrategyResponse response, string resultFileName);
        void FinishRun();
    }
}
