using MediatR;

namespace Insurise.Application.Features.Common.ChainElements.Queries.GetChainElementList;

public class ChainElementListQuery : IRequest<List<ChainElementDto>>
{
}