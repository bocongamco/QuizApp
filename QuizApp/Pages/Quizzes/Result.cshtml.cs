using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuizApp.Pages.Quizzes
{
    public class ResultModel : PageModel
    {
        public int Score { get; set; }
        public int TotalQuestions { get; set; }

        public void OnGet()
        {
            Score = (int)(TempData["Score"] ?? 0);
            TotalQuestions = (int)(TempData["TotalQuestions"] ?? 0);
        }
    }
}
