using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.MemberDashboard
{
    public class LastDestinations : ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public LastDestinations(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetLast4Destinations();
            return View(values);
        }
    }
}
