using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityFramework
{
    public class EFCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetListCommentWithDestination()
        {
            using (var c = new Context())
            {
                return c.Comments.Include(x => x.Destination).Include(x => x.AppUser)
                       .OrderByDescending(x => x.CommentId).ToList();
            }
        }

        public List<Comment> GetListCommentWithDestinationAndUser(int id)
        {
            using (var context = new Context())
            {
                return context.Comments
                            .Include(x => x.Destination)
                            .Include(x => x.AppUser)
                            .Where(x => x.AppUserId == id)
                            .OrderByDescending(x => x.CommentId) 
                            .ToList();
            }
        }

        public List<Comment> GetCommentsByDestinationId(int id)
        {
            using (var context = new Context())
            {
                return context.Comments
                    .Include(x => x.AppUser)
                    .Where(x => x.DestinationId == id)
                    .OrderByDescending(x => x.CommentDate)
                    .ToList();
            }
        }

        public List<Comment> GetCommentsWithUserByDestinationId(int id)
        {
            return GetCommentsByDestinationId(id);
        }
    }
}
