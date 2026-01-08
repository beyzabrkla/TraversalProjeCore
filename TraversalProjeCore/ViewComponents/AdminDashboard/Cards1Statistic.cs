using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace TraversalProjeCore.ViewComponents.AdminDashboard
{
    public class Cards1Statistic : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Destinations.Count();
            ViewBag.v2 = c.Users.Count();
            return View();
        }
    }
}
