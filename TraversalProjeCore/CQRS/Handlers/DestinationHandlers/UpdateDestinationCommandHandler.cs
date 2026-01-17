using DataAccessLayer.Concrete;
using TraversalProjeCore.CQRS.Commands.DestinationCommands;

namespace TraversalProjeCore.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.DestinationId);
            values.City = command.City;
            values.DayNight = command.DayNight;
            values.Price = Convert.ToString(command.Price);
            _context.SaveChanges();
        }
    }
}
