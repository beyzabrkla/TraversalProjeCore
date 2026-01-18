using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.Destination
{
    public class GuideDetails : ViewComponent
    {
        private readonly IGuideService _guideService;

        public GuideDetails(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke()
        {
            var values= _guideService.TGetById(1);
            return View(values);
        }
    }
}
