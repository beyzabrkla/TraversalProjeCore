using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.MemberLayout
{
    public class MemberLayoutScripts : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
