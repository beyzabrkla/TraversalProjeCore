using DataAccessLayer.Concrete; // Context sınıfına erişim için şart
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalProjeCore.Areas.Member.Controllers
{
    [Area("Member")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        // Bu metodu kullanmadığını belirttin, boş kalabilir.
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> MemberDashboard()
        {
            // Giriş yapan kullanıcının bilgilerini getir
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserName = values.Name + " " + values.Surname;
            ViewBag.ImageUrl = values.ImageUrl;

            using var context = new Context();

            // Giriş yapan kullanıcıya özel istatistikler (ID üzerinden filtreleme)
            ViewBag.activeReservations = context.Reservations.Count(x => x.AppUserId == values.Id && x.Status == "Onaylandı");
            ViewBag.oldReservations = context.Reservations.Count(x => x.AppUserId == values.Id && x.Status == "Geçmiş");
            ViewBag.pendingReservations = context.Reservations.Count(x => x.AppUserId == values.Id && x.Status == "Onay Bekliyor");

            // Tüm acente geneli istatistikler
            ViewBag.totalRoutes = context.Destinations.Count();
            ViewBag.guideCount = context.Guides.Count();
            ViewBag.totalGuests = context.Reservations.Count();
            ViewBag.avgScore = "9.5/10";

            return View();
        }
    }
}