using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.MemberLayout
{
    public class MemberLayoutSidebar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
