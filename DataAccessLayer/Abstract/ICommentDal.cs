using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        public List<Comment> GetListCommentWithDestination();
        public List<Comment> GetListCommentWithDestinationAndUser(int id);
        public List<Comment> GetCommentsWithUserByDestinationId(int id);
    }
}
