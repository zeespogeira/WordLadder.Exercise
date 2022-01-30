using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WordLadder.Exercise.Contracts.Interfaces;
using WordLadder.Exercise.Contracts.ResponseObjs;

namespace WordLadder.Exercise.Implementations.Services
{
    public class FileService : ILoadWordsService, IRunResultService, IFileValidator
    {
        private HashSet<string> _words;

        public async Task<HashSet<string>> LoadAllFileLinesAsync(string path)
        {
            if (_words == null)
            {
                _words = new HashSet<string>(await File.ReadAllLinesAsync(path));
            }

            return _words;
        }

        public void HandleResult(WordLadderStrategyResponse strategyResponseDto, string fileName)
        {
            using var file = File.CreateText(fileName);
            foreach (var word in strategyResponseDto.Ladder)
            {
                file.WriteLine(word);
            }
        }

        public bool FileExist(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
