using MediatR;

namespace Insurise.Application.Features.Common.Natures.Queries.GetNatureDetail;

public class GetNatureDetailQuery : IRequest<NatureDto>
{
    public GetNatureDetailQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}