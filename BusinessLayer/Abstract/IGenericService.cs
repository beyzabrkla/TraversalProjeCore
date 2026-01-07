using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TAdd(T t);
        void TUpdate(T t);
        void TDelete(T t);
        T TGetById(int id);
        List<T> TGetList();
        //List<T> TGetListByFilter(Expression<Func<T, bool>> filter);
    }
}
