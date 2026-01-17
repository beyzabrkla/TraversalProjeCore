using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IGenericUOWDal<T> where T : class
    {
        void Insert(T t);
        T GetByID(int id);
        void Update(T t);
        void MultiUpdate(List<T> t); //birden fazla kaydı güncellemek için
    }
}
