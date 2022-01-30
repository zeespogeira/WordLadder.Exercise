using WordLadder.Exercise.Contracts.ResponseObjs;

namespace WordLadder.Exercise.Contracts.Interfaces
{
    public interface IRunResultService
    {
        void HandleResult(WordLadderStrategyResponse strategyResponseDto, string fileName);
    }
}
