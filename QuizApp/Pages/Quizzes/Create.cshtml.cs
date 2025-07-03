using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApp.Data;
using QuizApp.Models;

namespace QuizApp.Pages.Quizzes
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        
        [BindProperty]
        public Quiz Quiz { get; set; }
        
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
           Quiz = new Quiz();
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return Page();
            }

            foreach (var question in Quiz.Questions)
            {
                question.Id = Guid.NewGuid();
                question.QuizId = Quiz.Id;

                foreach (var answer in question.AnswerOptions)
                {
                    answer.Id = Guid.NewGuid();
                    answer.QuestionId = question.Id;
                }
            }
            _context.Quizzes.Add(Quiz);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
     }
}
