namespace WordLadder.Exercise.Contracts.DTOs
{
    public class StartWordDto
    {
        public string StartWord { get; }

        public StartWordDto(string startWord)
        {
            StartWord = startWord;
        }
    }
}
