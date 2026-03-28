using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.AdminDashboard
{
    public class TotalRevenue: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.CurrentYearRevenue = "₺ 47.520";
            ViewBag.LastYearRevenue = "₺ 41.210";
            ViewBag.GrowthRate = "62";

            return View();
        }
    }
}
