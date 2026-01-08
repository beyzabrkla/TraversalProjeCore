using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.AdminDashboard
{
    public class DashboardBanner : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
