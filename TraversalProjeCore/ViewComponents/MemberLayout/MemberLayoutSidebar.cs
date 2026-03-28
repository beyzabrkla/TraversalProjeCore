using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using TraversalProjeCore.Resources.Views.Shared;

namespace TraversalProjeCore.ViewComponents.MemberLayout
{
    public class MemberLayoutSidebar : ViewComponent
    {
        private readonly IHtmlLocalizer<_MemberLayout> _localizer;

        public MemberLayoutSidebar(IHtmlLocalizer<_MemberLayout> localizer)
        {
            _localizer = localizer;
        }

        public IViewComponentResult Invoke()
        {
            ViewData["Localizer"] = _localizer;
            return View();
        }
    }
}