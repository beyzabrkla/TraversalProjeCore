using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IDestinationDal : IGenericDal<Destination>
    {
        public List<Destination> GetDestinationWithGuide(int id) 
        {
            using (var c = new Context())
            {
                return c.Destinations.Where(x => x.DestinationId == id).Include(x => x.Guide).ToList();
            }
        }
    }
}
