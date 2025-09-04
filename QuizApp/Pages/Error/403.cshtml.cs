using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuizApp.Pages.Error
{
    public class _403Model : PageModel
    {

        public IActionResult OnPost()
        {
            return RedirectToPage("/Quizzes/Index");
        }
        public void OnGet()
        {
        }
    }
}
