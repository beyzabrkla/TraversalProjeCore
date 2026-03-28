using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.MemberLayout
{
    public class MemberLayoutLanguages : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
