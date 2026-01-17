using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract.AbstractUOW
{
    public interface IGenericUOWService<T>
    {
        void TInsert(T t);
        T TGetByID(int id);

        void TUpdate(T t);
        void TMultiUpdate(List<T> t); //birden fazla kaydı güncellemek için

    }
}
