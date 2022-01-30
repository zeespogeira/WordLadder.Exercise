namespace WordLadder.Exercise.Contracts.DTOs
{
    public class WordFileDto
    {
        public string Path { get; }

        public WordFileDto(string path)
        {
            Path = path;
        }
    }
}
