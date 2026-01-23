using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.Areas.Member.Controllers
{
    [Area("Member")]
    public class LastDestinationsController : Controller
    {

        private readonly IDestinationService _destinationService;

        public LastDestinationsController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetLast4Destinations();
            return View(values);
        }
    }
}
