using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.MemberLayout
{
    public class MemberLayoutHead :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
