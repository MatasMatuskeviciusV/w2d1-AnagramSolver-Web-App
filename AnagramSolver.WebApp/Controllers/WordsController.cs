using AnagramSolver.Contracts;
using AnagramSolver.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnagramSolver.WebApp.Controllers
{
    public class WordsController : Controller
    {
        private readonly IWordRepository _repo;

        public WordsController(IWordRepository repo)
        {
            _repo = repo; 
        }

        public IActionResult Index(int page = 1)
        {
            int pageSize = 100;
            if (page < 1)
            {
                page = 1;
            }

            var allWords = _repo.GetAllWords();

            var totalCount = allWords.Count();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            if (page > totalPages)
            {
                page = totalPages;
            }

            var items = allWords.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var vm = new WordsPageViewModel();

            vm.HasPrevious = page > 1;
            vm.HasNext = page < totalPages;

            vm.Items = items;
            vm.CurrentPage = page;
            vm.TotalPages = totalPages;

            return View(vm);
        }
    }
}
