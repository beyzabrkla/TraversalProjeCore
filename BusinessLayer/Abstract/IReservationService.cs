using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IReservationService : IGenericService<Reservation>
    {
        List<Reservation> GetListWithByReservationByAccepted(int id);
        List<Reservation> GetListWithByReservationByPrevious(int id);
        List<Reservation> GetListWithReservationByWaitApproval(int id);

    }
}
