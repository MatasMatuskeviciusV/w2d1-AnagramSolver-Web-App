namespace AnagramSolver.WebApp.Models
{
    public class WordsPageViewModel
    {
        public List<string> Items { get; set; } = new();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public bool HasPrevious;
        public bool HasNext;
    }
}
