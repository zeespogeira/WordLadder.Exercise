namespace WordLadder.Exercise.Contracts.DTOs
{
    public class ResultFileDto
    {
        public string FileName { get; }

        public ResultFileDto(string fileName)
        {
            FileName = fileName;
        }
    }
}
