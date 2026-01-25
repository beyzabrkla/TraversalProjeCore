using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalProjeCore.ViewComponents.AdminDashboard
{
    public class AdminLastMessages : ViewComponent
    {
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            // Son gelen 5 mesajı çekiyoruz
            var values = c.ContactUses
                          .OrderByDescending(x => x.ContactUsId)
                          .Take(5)
                          .ToList();
            return View(values);
        }
    }
}