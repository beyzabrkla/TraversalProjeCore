using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MediatR;
using TraversalProjeCore.CQRS.Commands.GuideCommands;

namespace TraversalProjeCore.CQRS.Handlers.GuideHandlers
{
    public class CreateGuideCommandHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken) //Unit = mediatr de  
        {
            _context.Guides.Add(new Guide
            {
                Name = request.Name,
                Description = request.Description,
                Status = true
            });

            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
