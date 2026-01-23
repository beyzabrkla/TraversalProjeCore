using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.MemberLayout
{
    public class MemberLayoutHeaderContent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
