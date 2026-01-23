using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.MemberLayout
{
    public class MemberLayoutFooter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
