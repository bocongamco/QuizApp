using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Models;

namespace QuizApp.Pages.Quizzes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Quiz> Quizzes { get; set; } 

        public async Task OnGet()
        {
            Quizzes = await _context.Quizzes.ToListAsync();
        }
    }
}
