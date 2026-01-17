using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.UnitOfWork
{
    public class UOWDal : IUOWDal
    {
        private readonly Context _context;

        public UOWDal(Context context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
