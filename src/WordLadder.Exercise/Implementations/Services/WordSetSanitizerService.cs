using System.Collections.Generic;
using System.Linq;
using WordLadder.Exercise.Contracts.Interfaces;
using WordLadder.Exercise.Misc;

namespace WordLadder.Exercise.Implementations.Services
{
    public class WordSetSanitizerService : IWordSetSanitizerService
    {
        /// <summary>
        /// Enforces sanitation rules on the word set (trims and filter words only with the correct size)
        /// </summary>
        /// <param name="words">word set</param>
        /// <returns>sanitized word set</returns>
        public IEnumerable<string> Sanitize(string[] words)
        {
            //guard
            if (words == null || !words.Any())
            {
                return new List<string>();
            }


            return words.Trim()
                        .RemoveDuplicates()
                        .FilterWithSizeOf(Constants.ExpectedWordSize);
        }
    }
}
