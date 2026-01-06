using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalProjeCore.Models;

namespace TraversalProjeCore.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public LoginController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {
            if (string.IsNullOrWhiteSpace(p.Name) ||
                string.IsNullOrWhiteSpace(p.Surname) ||
                string.IsNullOrWhiteSpace(p.Username) ||
                string.IsNullOrWhiteSpace(p.Mail))
            {
                ModelState.AddModelError("", "Tüm Girişleri Doldurun");
                return View(p);
            }

            AppUser appUser = new AppUser()
            {
                Name = p.Name!,
                Surname = p.Surname!,
                UserName = p.Username!,
                Email = p.Mail!,
                ImageUrl = string.Empty, 
                Gender = string.Empty    
            };
            if (!string.IsNullOrEmpty(p.Password) && p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
