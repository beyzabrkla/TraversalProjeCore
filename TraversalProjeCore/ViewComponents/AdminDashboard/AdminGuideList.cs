using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.AdminDashboard
{
    public class AdminGuideList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
