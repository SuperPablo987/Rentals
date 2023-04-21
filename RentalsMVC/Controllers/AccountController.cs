using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RentalsData;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RentalsMVC.Controllers
{
    public class AccountController : Controller
    {
        // Route: /Account/Login
        public IActionResult Login(string returnUrl = "")
        {
            if(returnUrl != null)
            {
                TempData["ReturnUrl"] = returnUrl;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(User user) // data collected on the form
        {
            User usr = UserManager.Authenticate(user.Username, user.Password);
            if (usr == null) // not authenticated/ authentication failed
            {
                return View(); // stay on the login page
            }
            // usr != null - authentication passed

            // if the user is an owner, add to session state
            if(usr.Role == "Owner")
            {
                HttpContext.Session.SetInt32("CurrentOwner", (int)usr.OwnerID); 
            }
            
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usr.Username),
                new Claim("FullName", usr.FullName),
                new Claim(ClaimTypes.Role, usr.Role)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, 
                CookieAuthenticationDefaults.AuthenticationScheme); // use cookies authentication
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.
                AuthenticationScheme, claimsPrincipal); // generates authentication cookie
            // if no return URL go to the home page
            if (string.IsNullOrEmpty(TempData["ReturnUrl"].ToString()))
            {
                return RedirectToAction("Index", "Rentals"); // redicrect to action of controller
            }
            else
            {
                return Redirect(TempData["ReturnUrl"].ToString());
            }
        } 

        public async Task<IActionResult> LogoutAsync()
        {
            // release authentication cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.
                AuthenticationScheme);
            // remove current onwer from the session
            HttpContext.Session.Remove("CurrentOwner");

            return RedirectToAction("Index", "Rentals"); // go to the home page
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
