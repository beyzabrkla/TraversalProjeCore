using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace TraversalProjeCore.ViewComponents.Comment
{
    public class CommentList : ViewComponent
    {
        private readonly ICommentService _commentService;
        public CommentList(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            int page = 1;
            if (Request.Query.ContainsKey("page"))
            {
                int.TryParse(Request.Query["page"], out page);
            }

            var values = _commentService.TGetListCommentWithDestinationAndUser(id);

            ViewBag.destID = id;

            return View(values.ToPagedList(page, 3));
        }
    }
}