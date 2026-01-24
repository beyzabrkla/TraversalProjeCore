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
        public List<Comment> GetListCommentWithDestination() // Yorumları destinasyonlarıyla birlikte getiren metot
        {
            using (var c = new Context()) // Context nesnesi oluşturuldu
            {
                return c.Comments.Include(x => x.Destination).ToList(); // Yorumları ve ilişkili destinasyonları içeren liste döndürüldü
            }
        }

        public List<Comment> GetListCommentWithDestinationAndUser(int id)
        {
            using (var context = new Context())
            {
                return context.Comments
                    .Include(x => x.Destination)
                    .Where(x => x.AppUserId == id)
                    .OrderByDescending(x => x.CommentDate) 
                    .ToList();
            }
        }
    }
}
