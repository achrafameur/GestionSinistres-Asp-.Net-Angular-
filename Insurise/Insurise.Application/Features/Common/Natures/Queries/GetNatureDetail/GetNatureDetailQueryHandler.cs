using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Natures.Queries.GetNatureDetail;

public class GetNatureDetailQueryHandler : IRequestHandler<GetNatureDetailQuery, NatureDto>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Nature> _natureRepository;

    public GetNatureDetailQueryHandler(IMapper mapper, IRepository<Nature> natureRepository)
    {
        _natureRepository = natureRepository;
        _mapper = mapper;
    }

    public async Task<NatureDto> Handle(GetNatureDetailQuery request, CancellationToken cancellationToken)
    {
        var nature = await _natureRepository.GetByIdAsync(request.Id);
        var natureDetailDto = _mapper.Map<NatureDto>(nature);
        return natureDetailDto;
    }
}