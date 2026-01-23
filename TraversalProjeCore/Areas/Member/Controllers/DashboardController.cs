using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.Areas.Member.Controllers
{
    [Area("Member")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name); 
            ViewBag.UserName = values.Name +" "+ values.Surname;
            ViewBag.ImageUrl = values.ImageUrl;
            return View();
        }

        public async Task<IActionResult> MemberDashboard()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserName = values.Name + " " + values.Surname;
            ViewBag.ImageUrl = values.ImageUrl;
            return View();
        }
    }
}
