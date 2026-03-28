using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
