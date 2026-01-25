using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TAdd(Comment t)
        {
         _commentDal.Insert(t);
        }

        public void TDelete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public Comment TGetById(int id)
        {
            return _commentDal.GetById(id); 
        }

        public List<Comment> TGetList()
        {
           return _commentDal.GetList();
        }
        
        public List<Comment> TGetDestinationById(int id)
        {
            return _commentDal.GetListByFilter(x=>x.DestinationId==id);
        }

        public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }

        public List<Comment> TGetListCommentWithDestination()
        {
            return _commentDal.GetListCommentWithDestination();
        }

        public List<Comment> TGetListCommentWithDestinationAndUser(int id)
        {
            return _commentDal.GetListCommentWithDestinationAndUser(id);
        }

        public List<Comment> TGetCommentsWithUserByDestinationId(int id)
        {
            return _commentDal.GetCommentsWithUserByDestinationId(id);
        }
    }
}
