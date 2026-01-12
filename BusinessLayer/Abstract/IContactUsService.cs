using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IContactUsService :IGenericService<ContactUs>
    {
        List<ContactUs> TGetListContactUsByTrue();
        List<ContactUs> TGetListContactUsByFalse();
        void TContactUsStatusChangeToFalse(int it);
    }
}
