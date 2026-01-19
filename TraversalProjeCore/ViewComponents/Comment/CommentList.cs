using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProjeCore.ViewComponents.Comment
{
    public class CommentList: ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EFCommentDal());
        Context context = new Context();
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.commentCount = context.Comments.Where(x => x.DestinationId == id).Count();
            var values = commentManager.TGetListCommentWithDestinationAndUser(id);
            return View(values);
        }
    }
}
