using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace fincheckup.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required]
        [DataType(DataType.EmailAddress)]
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public String? UserID { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        // password 
        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public String? UserPassword { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        // remember me 
        [BindProperty]
        public Boolean RememberMe { get; set; }
        private readonly SignInManager<IdentityUser> _sm;

        public LoginModel(SignInManager<IdentityUser> sm)
        {

            _sm = sm;

        }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public async Task<IActionResult> OnPostAsync(string? returnUrl)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        {

            if (ModelState.IsValid)
            {

                var result = await _sm.PasswordSignInAsync(
                    UserID, UserPassword, RememberMe, lockoutOnFailure: true);

                if (result.Succeeded)
                {

                    return LocalRedirect(returnUrl ?? "~/");

                }

                else if (result.RequiresTwoFactor)
                {

                    // ModelState.AddModelError( 
                    // string.Empty, 
                    // "2-factor authentication to be implemented later."); 

                    return RedirectToPage("/LoginWith2fa",
                        new
                        {
                            area = "auth",
                            rememberMe = RememberMe,
                            returnUrl = returnUrl
                        });

                }

                else if (result.IsLockedOut)
                {

                    // to implement later 
                    // throw new NotImplementedException(); 

                    return RedirectToPage("Lockout", new { area = "auth" });

                }

                else
                {

                    // display the count of failed attempts 
                    IdentityUser user = await _sm.UserManager.FindByEmailAsync(UserID);

                    String message = "Login failed.";

                    if (null != user)
                    {

                        int fail = await _sm.UserManager.GetAccessFailedCountAsync(user);

                        int total = _sm.Options.Lockout.MaxFailedAccessAttempts;

                        message += $" Unsuccessful attempts {fail} of {total}";

                    }

                    // add to validation summary 
                    ModelState.AddModelError(string.Empty, message);

                }

            }

            return Page();

        }
    }
}
