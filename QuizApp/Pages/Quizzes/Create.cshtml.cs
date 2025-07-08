using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApp.Data;
using QuizApp.Models;

namespace QuizApp.Pages.Quizzes
{
    [Authorize(Roles ="Admin")]
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
                //Assigned foreign key for quizId
                question.QuizId = Quiz.Id;

                foreach (var answer in question.AnswerOptions)
                {
                    answer.Id = Guid.NewGuid();
                    //Assigned foreign key for QuestionId
                    answer.QuestionId = question.Id;
                }
            }
            _context.Quizzes.Add(Quiz);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
     }
}
