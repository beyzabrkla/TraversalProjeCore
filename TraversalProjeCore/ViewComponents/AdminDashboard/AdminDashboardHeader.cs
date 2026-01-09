using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.AdminDashboard
{
    public class AdminDashboardHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
