using Insurise.Application.Features.Common.Chains.Queries.GetChainList;
using MediatR;

namespace Insurise.Application.Features.Common.Chains.Queries.GetChainDetail;

public class GetChainDetailQuery : IRequest<ChainDto>
{
    public GetChainDetailQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}