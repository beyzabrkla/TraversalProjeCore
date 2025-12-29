using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
