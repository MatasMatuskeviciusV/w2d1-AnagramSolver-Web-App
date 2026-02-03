using AnagramSolver.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AnagramSolver.Contracts;
using AnagramSolver.BusinessLogic;

namespace AnagramSolver.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnagramSolver _solver;
        private readonly IConfiguration _configuration;
        private readonly IUserInputProcessor _user;

        public HomeController(IAnagramSolver solver, IConfiguration configuration, IUserInputProcessor user)
        {
            _solver = solver;
            _configuration = configuration;
            _user = user;
        }

        public IActionResult Index(string? id)
        {
            var vm = new AnagramViewModel();
            var minUserInput = _configuration.GetValue<int>("minUserInputLength");

            if (!string.IsNullOrEmpty(id))
            {
                vm.HasInput = true;

                if (id.Length < minUserInput)
                {
                    vm.IsShort = true;
                }
                else
                {
                    var sortedLetters = _user.GetSortedLetters(id);
                    vm.Results = _solver.GetAnagrams(sortedLetters);
                    vm.IsShort = false;
                }
            }
            else
            {
                vm.HasInput = false;
            }

                return View(vm);
        }
    }
}
