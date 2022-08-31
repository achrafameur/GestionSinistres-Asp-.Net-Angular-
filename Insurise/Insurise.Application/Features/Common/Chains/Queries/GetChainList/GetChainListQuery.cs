using MediatR;

namespace Insurise.Application.Features.Common.Chains.Queries.GetChainList;

public class GetChainListQuery : IRequest<List<ChainDto>>
{
}