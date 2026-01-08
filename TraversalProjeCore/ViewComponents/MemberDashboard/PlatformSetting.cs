using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.MemberDashboard
{
    public class PlatformSetting : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
