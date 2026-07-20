using fincheckup.Models.Hvvn;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace fincheckup.Pages
{
    public class LoginWith2faModel : PageModel
    {
        private readonly SignInManager<HhvnUsers> _sm;

        public LoginWith2faModel(SignInManager<HhvnUsers> sm)
        {

            _sm = sm;

        }


        // return url 
        [BindProperty]
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? ReturnUrl { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        // remember me 
        [BindProperty]
        public bool RememberMe { get; set; }

        // 2-factor code 
        [BindProperty]
        [Required]
        public string TwoFactorCode { get; set; } = default!;

        // OnGet 
        public async Task<IActionResult> OnGetAsync(
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
              bool rememberMe, string? returnUrl = null)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        {

            // Ensure the user has gone through the 
            // first login page 
            var user = await _sm.GetTwoFactorAuthenticationUserAsync();

            if (user == null)
            {

                // error 
                return NotFound();

            }

            ReturnUrl = returnUrl;

            RememberMe = rememberMe;

            return Page();

        }

        // OnPost 
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {

                return Page();

            }

            String returnUrl = ReturnUrl ?? Url.Content("~/");

            // Ensure the user has gone through the 
            // first login page 
            var user = await _sm.GetTwoFactorAuthenticationUserAsync();

            if (user == null)
            {

                // error 
                return NotFound();

            }

            var authCode = TwoFactorCode
              .Replace(" ", string.Empty)
              .Replace("-", string.Empty);

            var result = await _sm.TwoFactorAuthenticatorSignInAsync(authCode,
                    RememberMe, RememberMe);

            if (result.Succeeded)
            {

                return LocalRedirect(returnUrl);

            }

            else if (result.IsLockedOut)
            {

                return RedirectToPage("./Lockout");

            }

            else
            {

                ModelState.AddModelError(string.Empty, "Invalid auth code.");

                return Page();

            }

        }
    }
}
