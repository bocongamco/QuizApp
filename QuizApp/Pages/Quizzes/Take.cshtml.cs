using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApp.Models;
using QuizApp.Services;
using QuizApp.ViewModel;

namespace QuizApp.Pages.Quizzes
{
    [Authorize]
    public class TakeModel : PageModel
    {
        private readonly IQuizService _quizService;
        public TakeModel(IQuizService quizService)
        {
            _quizService = quizService;
        }
        [BindProperty]
        public Quiz Quiz { get; set; }

        [BindProperty]
        public QuizAttemptViewModel Attempt { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Quiz = await _quizService.GetQuizWithQuestionsAsync(id);
            if (Quiz == null)
            {
                return NotFound();
            }

            //create new empty answer sheets
            Attempt = new QuizAttemptViewModel
            {
                QuizId = Quiz.Id,
                Questions = Quiz.Questions.Select(q => new QuestionAttempt
                {
                    QuestionId = q.Id,
                    
                }).ToList()
            };
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            var Quiz = await _quizService.GetQuizWithQuestionsAsync(Attempt.QuizId);
            if (Quiz == null)
            {
                return NotFound();
            }

            int score = _quizService.CalculateScore(Quiz, Attempt.Questions.ToDictionary(q => q.QuestionId, q => q.SelectedAnswerId));
            TempData["Score"] = score;
            TempData["TotalQuestions"] = Quiz.Questions.Count;
            return RedirectToPage("Result");
        }
    }
}
