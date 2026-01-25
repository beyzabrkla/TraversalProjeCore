using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using X.PagedList; // Bunu eklemeyi unutma

namespace TraversalProjeCore.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService; // Manager yerine Service kullanıyoruz
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        [HttpGet]
        public PartialViewResult AddComment() => PartialView();
        

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment p)
        {
            if (string.IsNullOrWhiteSpace(p.CommentContent)) return BadRequest();

            // Giriş yapan güncel kullanıcıyı yakala
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            p.AppUserId = user.Id; 
            p.CommentDate = DateTime.Now;
            p.CommentState = true;

            _commentService.TAdd(p);

            // Yorumdan sonra detay sayfasına, aynı tura geri dön
            return RedirectToAction("DestinationDetails", "Destination", new { id = p.DestinationId });
        }

        public IActionResult CommentListPartial(int id, int page = 1)
        {
            var values = _commentService.TGetListCommentWithDestinationAndUser(id);
            var pagedList = values.ToPagedList(page, 3);
            ViewBag.destID = id;

            return PartialView("~/Views/Shared/Components/CommentList/Default.cshtml", pagedList);
        }
    }
}