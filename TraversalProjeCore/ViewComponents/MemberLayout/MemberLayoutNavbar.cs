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
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user); // Veriyi model olarak gönderdik
        }
    }
}