using MediatR;
using TraversalProjeCore.CQRS.Results.GuideResults;

namespace TraversalProjeCore.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery: IRequest<List<GetAllGuideQueryResult>>
    {
    }
}
