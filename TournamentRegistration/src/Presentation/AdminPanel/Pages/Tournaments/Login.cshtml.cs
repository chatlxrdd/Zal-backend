using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebApi.Services; // Dodaj to
using Core.Entities; // Dodaj to

namespace AdminPanel.Pages.Tournaments
{
    public class LoginModel : PageModel
    {
        private readonly IAuthService _authService;

        public LoginModel(IAuthService authService)
        {
            _authService = authService;
        }

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = new User { Username = Username, Password = Password };
            var token = _authService.GenerateJwtToken(user);

            if (string.IsNullOrEmpty(token))
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            Response.Cookies.Append("jwt", token);
            return RedirectToPage("/Index");
        }
    }
}
