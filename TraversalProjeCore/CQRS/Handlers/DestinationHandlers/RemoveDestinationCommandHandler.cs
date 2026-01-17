using DataAccessLayer.Concrete;
using TraversalProjeCore.CQRS.Commands.DestinationCommands;

namespace TraversalProjeCore.CQRS.Handlers.DestinationHandlers
{
    public class RemoveDestinationCommandHandler
    {
        private readonly Context _context;

        public RemoveDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handler(RemoveDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.Id);
            _context.Destinations.Remove(values);
            _context.SaveChanges(); 
        }
    }
}
