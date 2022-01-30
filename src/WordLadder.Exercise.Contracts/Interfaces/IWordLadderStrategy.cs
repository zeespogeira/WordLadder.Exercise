using System.Collections.Generic;
using WordLadder.Exercise.Contracts.ResponseObjs;

namespace WordLadder.Exercise.Contracts.Interfaces
{
    public interface IWordLadderStrategy
    {
        WordLadderStrategyResponse FindShortestLadders(string startWord, string endWord, HashSet<string> words);
    }
}
