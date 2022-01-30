using System.Collections.Generic;

namespace WordLadder.Exercise.Contracts.DTOs
{
    public class EndWordDto
    {
        public string EndWord { get; }
        public HashSet<string> Words { get; }

        public EndWordDto(string endWord, HashSet<string> words)
        {
            EndWord = endWord;
            Words = words;
        }
    }
}
