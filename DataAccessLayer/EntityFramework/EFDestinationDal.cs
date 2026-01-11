using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
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

    }
}

