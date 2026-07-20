using fincheckup.Context;
using fincheckup.Models.Hvvn;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace fincheckup.Controllers
{
    [Route("JsonService/Havvana/[action]")]
    public class HvvnController : Controller
    {

        public HvvnController()
        {
        }


        [ValidateAntiForgeryToken]
        public IActionResult LoginProcess(AddressFormVm model)
        {
            if (ModelState.IsValid)
            {


                var appUser = fincheckup.Models.Hvvn.HhvnUsers.GetPasswordwithAppUser(model.name);

                if (appUser == null || !(appUser.ID > 0) || appUser.qnbCorporateId=="77777771")
                {
                    TempData["Fail"] = "Kullanıcı bulunamadı.";

                    return Json("nok");
                }


                string userAgent = Request.Headers["User-Agent"];
                string remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();

                UserLogin nuser = new UserLogin();

                if (!appUser.IsActive)
                {
                    TempData["Fail"] = "Hesabınız aktif değil.";
                    return Json("nok");
                }
                string hashh = PassWordHash.Encrypt(model.pass);
                string hashhz = PassWordHash.Decrypt(appUser.Password);
                if (hashh != appUser.Password)
                {
                    TempData["Fail"] = "Kullanıcı adı veya şifre hatalı.";

                    return Json("nok");
                }
                else
                {
                    nuser.UserBrowser = userAgent; nuser.UserIP = remoteIpAddress;
                    nuser.UserID = appUser.ID;
                    nuser.Save_User();

                    SignIn(appUser);

                    if (string.IsNullOrEmpty(appUser.qnbUserId))
                    {
                        RedirectToPage("/Admin/firmpanel");
                        return Json("1");
                    }
                    else
                    {
                        RedirectToPage("/Admin/qnb/index");
                        return Json("3");
                    }
                }


            }

            return BadRequest(ModelState);
        }
        private void SignIn(HhvnUsers User)
        {

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, User.ID.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, User.Email));
            identity.AddClaim(new Claim(ClaimTypes.Role, User.UserType));
            string role = User.UserType;
            identity.AddClaim(new Claim("RoleId", role));

            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
 principal,
 new AuthenticationProperties
 {
     IssuedUtc = DateTime.UtcNow,
     IsPersistent = false,
     ExpiresUtc = DateTime.UtcNow.AddMinutes(35)
 });
        }



        public IActionResult LoginMogin([FromBody]object model)
        {
            var result = model;
            return Json("result");
             
        }




    }
}