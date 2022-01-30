using System.Collections.Generic;
using System.Threading.Tasks;

namespace WordLadder.Exercise.Contracts.Interfaces
{
    public interface ILoadWordsService
    {
        Task<HashSet<string>> LoadAllFileLinesAsync(string path);
    }
}
