using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/User")] 
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;

        public UserController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
        }

        [Route("Index")] 
        public IActionResult Index()
        {
            var values = _appUserService.TGetList();
            return View(values);
        }

        [Route("DeleteUser/{id}")] 
        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            var values = _appUserService.TGetById(id);
            _appUserService.TDelete(values);
            return RedirectToAction("Index");
        }

        [Route("EditUser/{id}")] 
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values = _appUserService.TGetById(id);
            return View(values);
        }

        [Route("EditUser/{id}")]
        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
            _appUserService.TUpdate(appUser);
            return RedirectToAction("Index");
        }

        [Route("CommentUser/{id}")] 
        public IActionResult CommentUser(int id)
        {
            _appUserService.TGetById(id);
            return View();
        }

        [Route("ReservationUser/{id}")] 
        public IActionResult ReservationUser(int id)
        {
            var values = _reservationService.GetListWithByReservationByAccepted(id);
            return View(values);
        }
    }
}