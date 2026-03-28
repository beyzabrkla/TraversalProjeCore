using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalProjeCore.ViewComponents.AdminDashboard
{
    public class DashboardBanner : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardBanner(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Giriş yapan kullanıcının bilgilerini alalım
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.AdminName = user.Name + " " + user.Surname;

            // Buraya ileride veritabanından gerçek istatistikleri bağlayabilirsin
            ViewBag.TotalSubscribers = 26955;
            ViewBag.NewSubscribers = 824;

            return View();
        }
    }
}