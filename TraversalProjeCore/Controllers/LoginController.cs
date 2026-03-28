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
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInViewModel p)
        {
            if (ModelState.IsValid) //eğer model geçerliyse
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, false, true); //kullanıcı adı ve şifreye göre giriş yapma işlemi
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Profile", new {area="Member"}); //başarılı girişte yönlendirme
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı Kullanıcı Adı Veya Şifre");
                    return RedirectToAction("SignIn", "Login");
                }
            }
            return View(p);
        }


        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p) //kullanıcı kayıt işlemi
        {
            //gerekli alanların doldurulup doldurulmadığını kontrol etme
            if (string.IsNullOrWhiteSpace(p.Name) ||
                string.IsNullOrWhiteSpace(p.Surname) ||
                string.IsNullOrWhiteSpace(p.Username) ||
                string.IsNullOrWhiteSpace(p.Mail))
            {
                ModelState.AddModelError("", "Tüm Girişleri Doldurun");
                return View(p);
            }
            //şifre ve onay şifresinin eşleşip eşleşmediğini kontrol etme
            AppUser appUser = new AppUser()
            {
                Name = p.Name!,
                Surname = p.Surname!,
                UserName = p.Username!,
                Email = p.Mail!,
                ImageUrl = string.Empty, 
                Gender = string.Empty    
            };
            //şifre ve onay şifresinin eşleşip eşleşmediğini kontrol etme
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

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn", "Login");
        }
    }
}
