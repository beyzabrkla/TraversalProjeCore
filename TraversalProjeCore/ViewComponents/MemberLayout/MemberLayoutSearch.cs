using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.MemberLayout
{
    public class MemberLayoutSearch : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
