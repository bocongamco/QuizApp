using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;

using System.Security.Claims;

namespace QuizApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        public async Task<IActionResult> OnPost(string email, string password)
        {
            if (email == "admin@admin" && password == "123123")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, email),
                    new Claim(ClaimTypes.Role, "Admin")
                };
                var identity = new ClaimsIdentity(claims, "CookieAuth");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("CookieAuth", principal);
                return RedirectToPage("/Quizzes/Index");
            }
            if (email == "student@student" && password == "123123")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, email),
                    new Claim(ClaimTypes.Role, "Student")
                };
                var identity = new ClaimsIdentity(claims, "CookieAuth");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("CookieAuth", principal);
                return RedirectToPage("/Quizzes/Index");
            }
            return Page();
        }
        
    }
}
