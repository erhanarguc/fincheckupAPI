using fincheckup.Models.Hvvn;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace fincheckup.Pages
{
    public class EnableAuthenticatorModel : PageModel
    {
        private readonly UserManager<HhvnUsers> _um;

        public EnableAuthenticatorModel(UserManager<HhvnUsers> um)
        {

            _um = um;

        }


        // key shown to the user 
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public String? SharedKey { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        // OnGet method where we set the above SharedKey 
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<IActionResult> OnGetAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {

            //IdentityUser user = await _um.GetUserAsync(User);

            //if (null == user)
            //{

            //    return NotFound("problem with the user account");

            //}

            //var authKey = await _um.GetAuthenticatorKeyAsync(user);

            //if (string.IsNullOrEmpty(authKey))
            //{

            //    await _um.ResetAuthenticatorKeyAsync(user);

            //    authKey = await _um.GetAuthenticatorKeyAsync(user);

            //}

            StringBuilder sbKey = new();

            // add space after 4 chars for visibility 
            //for (int i = 0; i < authKey.Length; i++)
            //{

            //    if (0 == (i % 4))
            //    {

            //        sbKey.Append(' ');

            //    }

            //    sbKey.Append(authKey[i]);

            //}

            //SharedKey = sbKey.ToString(); ;

            return Page();

        }

        [BindProperty]
        [Required]
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? Code { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        // message to be shown on redirect 
        // to TwoFactorAuth page 
        [TempData]
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? Message { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        // on post method when the user 
        // posts the token received from the 
        // authenticator app 
        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {

                String token =
                    Code!.Replace(" ", String.Empty).Replace("-", String.Empty);

                var user = await _um.GetUserAsync(User);

                var istokenValid = await _um.VerifyTwoFactorTokenAsync(
                    user, _um.Options.Tokens.AuthenticatorTokenProvider, token);

                if (istokenValid)
                {

                    var res = await _um.SetTwoFactorEnabledAsync(user, true);

                    if (res.Succeeded)
                    {

                        Message = "Authenticator App is verified!";

                        return RedirectToPage("./TwoFactorAuth");

                    }

                }

                ModelState.AddModelError(String.Empty, "Invalid code.");

            }

            return await OnGetAsync();

        }
    }
}
