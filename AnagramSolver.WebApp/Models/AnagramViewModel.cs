using System.Collections.Generic;

namespace AnagramSolver.WebApp.Models
{
    public class AnagramViewModel
    {
        public IList<string> Results { get; set; } = new List<string>();
        public bool IsShort { get; set; }
        public bool HasInput { get; set; }
    }
}