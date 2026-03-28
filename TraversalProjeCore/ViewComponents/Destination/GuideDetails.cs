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

        public IViewComponentResult Invoke(int id)
        {
            var values= _guideService.TGetById(id);
            return View(values);
        }
    }
}
