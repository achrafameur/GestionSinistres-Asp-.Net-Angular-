using Insurise.Application.Features.Common.ChainElements.Queries.GetChainElementList;
using MediatR;

namespace Insurise.Application.Features.Common.ChainElements.Queries.GetChainElementDetail;

public class GetChainElementDetailQuery : IRequest<ChainElementDto>
{
    public int Id { get; set; }
}