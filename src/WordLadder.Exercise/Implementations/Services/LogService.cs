using System;
using Microsoft.Extensions.Logging;
using WordLadder.Exercise.Contracts.Interfaces;

namespace WordLadder.Exercise.Implementations.Services
{
    public class LogService : ILogService
    {
        private readonly ILogger<Runner.Runner> _logger;

        public LogService(ILogger<Runner.Runner> logger)
        {
            _logger = logger;
        }

        public void LogInfo(string info)
        {
            _logger.LogInformation(info);
        }

        public void LogError(Exception ex, string error)
        {
            _logger.LogError(ex, error);
        }
    }
}
