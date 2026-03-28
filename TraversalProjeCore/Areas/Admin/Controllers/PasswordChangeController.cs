using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TraversalProjeCore.Areas.Admin.Models;
using TraversalProjeCore.Models; // ViewModel klasörün hangisiyse

[Area("Admin")]
public class PasswordChangeController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public PasswordChangeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Index() => View();

    [HttpPost]
    public async Task<IActionResult> Index(PasswordChangeViewModel p)
    {
        if (p.NewPassword != p.ConfirmPassword)
        {
            ModelState.AddModelError("", "Yeni şifreler birbiriyle eşleşmiyor.");
            return View();
        }

        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var result = await _userManager.ChangePasswordAsync(user, p.CurrentPassword, p.NewPassword);

        if (result.Succeeded)
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("SignIn", "Login", new { area = "" });
        }
        else
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }

        return View();
    }
}