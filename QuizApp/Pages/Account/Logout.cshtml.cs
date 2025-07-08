using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuizApp.Pages.Account
{
    public class LogoutModel : PageModel
    {
       public async Task<IActionResult> OnPost()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToPage("/Index");
        }
    }
}
