using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using QVision_Task.Models;
using QVision_Task.Repository;
using QVision_Task.ViewModels;
using System.Security.Claims;

namespace QVision_Task.Controllers
{
    public class AccountController : Controller
    {
        IAccountRepository accountRepo;
        public AccountController(IAccountRepository accRepo)
        {
            this.accountRepo = accRepo;
        }

        [HttpGet]
        public IActionResult Regist()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Regist(RegistVM newAcc)
        {
            if (ModelState.IsValid == true)
            {
                Account account = new Account();
                account.Name = newAcc.Name;
                account.Password = newAcc.Password;
                accountRepo.Create(account);
                accountRepo.Save();
                return RedirectToAction("Login");
            }
            return View(newAcc);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Name, string Password)
        {
            if (accountRepo.Find(Name, Password) == true)
            {
                Account account = accountRepo.GetAccount(Name, Password);
                ClaimsIdentity claims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()));
                claims.AddClaim(new Claim(ClaimTypes.Name, account.Name));
                claims.AddClaim(new Claim("Name", account.Name));
                ClaimsPrincipal principal = new ClaimsPrincipal(claims);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
