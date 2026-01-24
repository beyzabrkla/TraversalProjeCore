using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.MemberLayout
{
    public class MemberLayoutNavbar : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public MemberLayoutNavbar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Kullanıcı giriş yapmış mı kontrol et, yapmadıysa null döndürme riskine girme
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user == null)
            {
                // Güvenlik önlemi: Eğer bir şekilde buraya sızarsa Login'e gitsin
                return Content("Giriş Gerekli");
            }

            return View(user);
        }
    }
}