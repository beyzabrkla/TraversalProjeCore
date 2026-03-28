using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize]
    [Route("Member/[controller]/[action]")]
    public class DestinationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new EFDestinationDal());
        public IActionResult Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            // Veritabanındaki tüm rotaları ID'ye göre tersten sıralayıp son 4 tanesini alıyoruz
            var values = _destinationManager.TGetList()
                .OrderByDescending(x => x.DestinationId)
                .Take(4)
                .ToList();

            return View(values);
        }
    }
}
