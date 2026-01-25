using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public List<Reservation> GetListAllWithTables()
        {
            return _reservationDal.GetListAllWithTables();
        }

        public List<Reservation> GetListWithByReservationByAccepted(int id)
        {
            return _reservationDal.GetListByReservationByAccepted(id);
        }

        public List<Reservation> GetListWithByReservationByPrevious(int id)
        {
            return _reservationDal.GetListByReservationByPrevious(id);
        }

        public List<Reservation> GetListWithReservationByWaitApproval(int id)
        {
            return _reservationDal.GetListWithReservationByWaitApproval(id);
        }

        public void TAdd(Reservation t)
        {
            _reservationDal.Insert(t);
        }

        public void TDelete(Reservation t)
        {
            _reservationDal.Delete(t);
        }

        public Reservation TGetById(int id)
        {
            return _reservationDal.GetById(id);
        }

        public List<Reservation> TGetList()
        {
            return _reservationDal.GetListAllWithTables();
        }

        public List<Reservation> TGetListWithReservationByUserId(int id)
        {
            return _reservationDal.GetListWithReservationByUserId(id);
        }

        public void TUpdate(Reservation t)
        {
            _reservationDal.Update(t);
        }
    }
}
