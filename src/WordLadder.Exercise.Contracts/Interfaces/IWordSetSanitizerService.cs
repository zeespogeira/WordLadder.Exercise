using System.Collections.Generic;

namespace WordLadder.Exercise.Contracts.Interfaces
{
    public interface IWordSetSanitizerService
    {
        IEnumerable<string> Sanitize(string[] words);
    }
}
