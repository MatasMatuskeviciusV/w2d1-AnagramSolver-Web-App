using AnagramSolver.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramSolver.BusinessLogic
{
    public class UserInputProcessor : IUserInputProcessor
    {
        public string GetSortedLetters(string input)
        {
            var user = new UserProcessing(input);
            var words = user.GetWords();
            var sortedLetters = user.GetSortedLetters(words);

            return sortedLetters;
        }
    }
}
