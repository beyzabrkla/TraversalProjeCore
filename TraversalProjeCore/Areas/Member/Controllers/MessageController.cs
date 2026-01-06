using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.Areas.Member.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
