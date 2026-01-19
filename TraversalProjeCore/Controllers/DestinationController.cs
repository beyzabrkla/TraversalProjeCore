using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TraversalProjeCore.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EFDestinationDal());
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(IDestinationService destinationService, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> DestinationDetails(int id)
        {
            ViewBag.i = id;
            ViewBag.DestId = id;

            // Giriş yapan kullanıcı kontrolü
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    ViewBag.UserId = user.Id;
                }
            }
            var values = destinationManager.TGetDestinationWithGuide(id).FirstOrDefault();
            if (values == null) 
            { 
                return NotFound();
            } // Veritabanında id yoksa hata dönmesini engeller

          return View(values);
        }

        [HttpPost]
        public IActionResult DestinationDetails(Destination p)
        {
            return View();
        }
    }
}
