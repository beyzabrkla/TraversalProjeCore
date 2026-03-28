using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.AdminDashboard
{
    public class PartialNavbar : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public PartialNavbar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated) // Kullanıcı login mi?
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    ViewBag.NameSurname = user.Name + " " + user.Surname;
                    ViewBag.UserImage = user.ImageUrl ?? "/sneat-1.0.0/assets/img/avatars/1.png"; // Resim yoksa default resim
                    return View();
                }
            }

            // Giriş yapılmadıysa veya kullanıcı bulunamadıysa varsayılan değerler
            ViewBag.NameSurname = "Misafir Kullanıcı";
            ViewBag.UserImage = "/sneat-1.0.0/assets/img/avatars/1.png";
            return View();
        }
    }
}
