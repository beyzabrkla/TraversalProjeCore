using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.Areas.Member.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
