using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService; // ICommentService bağımlılığı

        public CommentController(ICommentService commentService)
        {
            this._commentService = commentService;
        }

        public IActionResult Index()
        {
            var values  = _commentService.TGetListCommentWithDestination(); // Yorumları Destination bilgileri ile birlikte getir
            return View(values);
        }

        public IActionResult DeleteComment(int id)
        {
            var value = _commentService.TGetById(id); // Yorum ID'sine göre yorumu getir
            _commentService.TDelete(value); // Yorumu sil
            return RedirectToAction("Index"); // Yönlendirme işlemi
        }
    }
}
