using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Models;

namespace QuizApp.Pages.Quizzes
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Quiz Quiz { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Quiz = await _context.Quizzes
            .Include(q => q.Questions)
                .ThenInclude(a => a.AnswerOptions)
            .FirstOrDefaultAsync(q => q.Id == id);

            if (Quiz == null)
                return NotFound();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var quiz = await _context.Quizzes
            .Include(q => q.Questions)
                .ThenInclude(a => a.AnswerOptions)
            .FirstOrDefaultAsync(q => q.Id == id);

            if (quiz != null)
            {
                _context.Quizzes.Remove(quiz);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
