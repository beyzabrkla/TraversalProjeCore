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
    public class EFDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public new Destination GetById(int id)
        {
            using var c = new Context();
            return c.Set<Destination>().FirstOrDefault(x => x.DestinationId == id);
        }

        public Destination GetDestinationWithGuide(int id)
        {
            using (var c = new Context())
            {
                return c.Destinations.Where(x => x.DestinationId == id).Include(x => x.Guide).FirstOrDefault();
            }
        }

        public List<Destination> GetLast4Destinations()
        {
            using (var c = new Context())
            {
                return c.Destinations.OrderByDescending(x => x.DestinationId).Take(4).ToList();
            }

        }
    }
}
