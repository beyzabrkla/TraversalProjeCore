using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/User")] // Tek bir ana rota tanımla
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;
        private readonly ICommentService _commentService;

        public UserController(IAppUserService appUserService, IReservationService reservationService, ICommentService commentService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
            _commentService = commentService;
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
            // 1. O kullanıcıya ait yorumları, rotalarıyla (Destination) birlikte getiriyoruz.
            // Not: Servis katmanında buna uygun bir metodun (örneğin TGetListWithCommentByUserId) olması gerekir.
            var values = _commentService.TGetListCommentWithDestinationAndUser(id);

            // 2. Çektiğimiz listeyi View'a (sayfaya) model olarak gönderiyoruz.
            return View(values);
        }

        [Route("ReservationUser/{id}")]
        public IActionResult ReservationUser(int id)
        {
            // Sadece 'Accepted' olanları değil, kullanıcıya ait TÜM rezervasyonları 
            // ve ilişkili kullanıcı bilgilerini getiren metodu kullanmalısın.
            var values = _reservationService.TGetListWithReservationByUserId(id);
            return View(values);
        }
    }
}