using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.Controllers
{
    [AllowAnonymous]
    public class GuideController : Controller
    {
        GuideManager guideManager = new GuideManager(new EFGuideDal());
        public IActionResult Index()
        {
            var values = guideManager.TGetList();
            return View(values);
        }
    }
}
