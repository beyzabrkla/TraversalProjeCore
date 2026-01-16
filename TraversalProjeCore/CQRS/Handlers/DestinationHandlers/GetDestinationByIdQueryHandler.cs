using DataAccessLayer.Concrete;
using TraversalProjeCore.CQRS.Queries.DestinationQueries;
using TraversalProjeCore.CQRS.Results.DestinationResults;

namespace TraversalProjeCore.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIdQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIdQueryResult Handle(GetDestinationByIdQuery query)
        {
            var values = _context.Destinations.Find(query.Id);
            return new GetDestinationByIdQueryResult
            {
                DestinaionId = values.DestinationId,
                City = values.City,
                DayNight = values.DayNight
            };
        }
    }
}
