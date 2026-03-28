using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal : IGenericDal<Reservation>
    {
        List<Reservation> GetListWithReservationByWaitApproval(int id);
        List<Reservation> GetListByReservationByAccepted(int id);
        List<Reservation> GetListByReservationByPrevious(int id);
        List<Reservation> GetListWithReservationByUserId(int id);
        List<Reservation> GetListAllWithTables();
    }
}
