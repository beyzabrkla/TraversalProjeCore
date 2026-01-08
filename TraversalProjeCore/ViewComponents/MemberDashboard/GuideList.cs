using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.MemberDashboard
{
    public class GuideList : ViewComponent
    {
        GuideManager guideManager = new GuideManager(new EFGuideDal());

        public IViewComponentResult Invoke()
        {
            var values = guideManager.TGetList();
            return View(values);
        }
    }
}
