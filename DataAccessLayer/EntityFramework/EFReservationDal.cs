using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityFramework
{
    public class EFReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> GetListByReservationByAccepted(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations
                    .Include(x => x.Destination)
                    .Where(x => x.AppUserId == id && x.Status == "Onaylandı")
                    .ToList();
            }
        }

        public List<Reservation> GetListByReservationByPrevious(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations
                    .Include(x => x.Destination)
                    .Where(x => x.AppUserId == id && x.Status == "Geçmiş Rezervasyon")
                    .ToList();
            }
        }

        public List<Reservation> GetListWithReservationByUserId(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations
                    .Include(x => x.Destination)
                    .Include(x => x.AppUser) 
                    .Where(x => x.AppUserId == id)
                    .ToList();
            }
        }

        public List<Reservation> GetListWithReservationByWaitApproval(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations
                    .Include(x => x.Destination)
                    .Where(x => x.AppUserId==id && x.Status == "Onay Bekliyor")
                    .ToList();
            }
        }

        public List<Reservation> GetListAllWithTables()
        {
            using (var context = new Context())
            {
                return context.Reservations
                    .Include(x => x.AppUser)      // Misafir adı için
                    .Include(x => x.Destination)  // Rota/Şehir adı için
                    .ToList();
            }
        }
    }
}
