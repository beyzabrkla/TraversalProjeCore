using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.Default
{
    public class SliderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
