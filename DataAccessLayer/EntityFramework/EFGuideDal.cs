using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityFramework
{
    public class EFGuideDal : GenericRepository<Guide>, IGuideDal
    {
        public void ChangeToFalseByGuide(int id)
        {
            Context context = new Context();
            var values = context.Guides.Find(id);
            if (values != null)
            {
                values.Status = false;
                context.Update(values);
                context.SaveChanges();
            }
        }

        public void ChangeToTrueByGuide(int id)
        {
            Context context = new Context();
            var values = context.Guides.Find(id);
            if (values != null)
            {
                values.Status = true;
                context.Update(values); 
                context.SaveChanges();
            }
        }
    }
}
