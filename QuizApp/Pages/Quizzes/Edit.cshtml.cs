using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Models;

namespace QuizApp.Pages.Quizzes
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Quiz Quiz { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Quiz = await _context.Quizzes
                .Include(q => q.Questions)
                    .ThenInclude(q => q.AnswerOptions)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (Quiz == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var existingQuiz = await _context.Quizzes
                .Include(q => q.Questions)
                    .ThenInclude(q => q.AnswerOptions)
                .FirstOrDefaultAsync(q => q.Id == Quiz.Id);

            if (existingQuiz == null)
                return NotFound();

            // Update quiz fields
            existingQuiz.Title = Quiz.Title;
            existingQuiz.TimeLimitInMinutes = Quiz.TimeLimitInMinutes;

            foreach (var updatedQuestion in Quiz.Questions)
            {
                var existingQuestion = existingQuiz.Questions.FirstOrDefault(q => q.Id == updatedQuestion.Id);
                if (existingQuestion != null)
                {
                    existingQuestion.QuestionText = updatedQuestion.QuestionText;

                    foreach (var updatedAnswer in updatedQuestion.AnswerOptions)
                    {
                        var existingAnswer = existingQuestion.AnswerOptions.FirstOrDefault(a => a.Id == updatedAnswer.Id);
                        if (existingAnswer != null)
                        {
                            existingAnswer.AnswerText = updatedAnswer.AnswerText;
                            existingAnswer.isCorrect = updatedAnswer.isCorrect;
                        }
                    }
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
