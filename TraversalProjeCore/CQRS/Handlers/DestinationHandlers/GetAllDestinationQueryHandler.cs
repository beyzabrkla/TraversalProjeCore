using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.EntityFrameworkCore;
using TraversalProjeCore.CQRS.Results.DestinationResults;

namespace TraversalProjeCore.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x=>new GetAllDestinationQueryResult
            {
                id = x.DestinationId,
                Capacity = x.Capacity,
                City=x.City,
                DayNight=x.DayNight,
                Price= Convert.ToDouble(x.Price)
            }).AsNoTracking().ToList();  //AsNoTracking -Bu veriyi sadece oku, üzerinde bir değişiklik yapıp veritabanına geri kaydetmeyeceğim, o yüzden boşuna takip etme" demektir.
            return values;
        }
    }
}
