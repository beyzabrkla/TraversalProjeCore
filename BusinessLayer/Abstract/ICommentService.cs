using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        List<Comment> TGetDestinationById(int id); //id ye göre destination ın yorumlarını getirir
        List<Comment> TGetListCommentWithDestination(); //yorumları destination bilgileri ile birlikte getirir
        public List<Comment> TGetListCommentWithDestinationAndUser(int id);
        List<Comment> TGetCommentsWithUserByDestinationId(int id);

    }
}
