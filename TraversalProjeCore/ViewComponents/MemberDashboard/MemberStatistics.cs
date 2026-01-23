using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.MemberDashboard
{
    public class MemberStatistics : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
