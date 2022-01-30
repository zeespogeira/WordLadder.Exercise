using System;

namespace WordLadder.Exercise.Contracts.Interfaces
{
    public interface ILogService
    {
        void LogInfo(string info);
        void LogError(Exception ex, string error);
    }
}
