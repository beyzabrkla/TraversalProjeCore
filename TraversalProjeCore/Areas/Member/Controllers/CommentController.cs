using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.Areas.Member.Controllers
{
    [Area("Member")]
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EFCommentDal());
        private readonly UserManager<AppUser> _userManager;

        public CommentController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var values = commentManager.TGetListCommentWithDestinationAndUser(user.Id);
            return View(values);
        }

        public IActionResult ChangeStatus(int id)
        {
            var value = commentManager.TGetById(id);
            value.CommentState = !(value.CommentState.GetValueOrDefault()); 
            commentManager.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}