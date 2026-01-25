using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalProjeCore.ViewComponents.AdminDashboard
{
    public class DestinationStatistics : ViewComponent
    {
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            // Veritabanındaki Rotalar tablosundan verileri alıyoruz
            // NullReferenceException almamak için verinin geldiğinden emin olmalıyız
            var values = c.Destinations.ToList();

            // Eğer veritabanından veri çekmeyeceksek ViewBag kullanmalıyız
            ViewBag.v1 = "42.82k";
            ViewBag.v2 = c.Destinations.Count().ToString();

            return View(values);
        }
    }
}