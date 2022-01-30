using System.Collections.Generic;

namespace WordLadder.Exercise.Contracts.ResponseObjs
{
    public class WordLadderStrategyResponse
    {
        public IList<string> Ladder { get; }
        public int NumberOfSteps => Ladder.Count;

        public WordLadderStrategyResponse(IList<string> ladder)
        {
            //guard
            Ladder = ladder ?? new List<string>();
        }
    }
}
