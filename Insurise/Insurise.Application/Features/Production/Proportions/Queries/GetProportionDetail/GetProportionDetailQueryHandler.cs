using AutoMapper;
using Insurise.Application.Features.Production.Proportions.Queries.GetProportionList;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Proportions.Queries.GetProportionDetail;

public class GetProportionDetailQueryHandler : IRequestHandler<GetProportionDetailQuery, ProportionDto>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Proportion> _proportionRepository;

    public GetProportionDetailQueryHandler(IMapper mapper, IRepository<Proportion> proportionRepository)
    {
        _mapper = mapper;
        _proportionRepository = proportionRepository;
    }

    public async Task<ProportionDto> Handle(GetProportionDetailQuery request, CancellationToken cancellationToken)
    {
        var proportion = await _proportionRepository.GetByIdAsync(request.ProportionId);
        var returnedProportion = _mapper.Map<ProportionDto>(proportion);
        return returnedProportion;
    }
}