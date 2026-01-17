using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract.AbstractUOW
{
    public interface IAccountService:IGenericUOWService<Account>
    {
    }
}
