using AutoMapper;
using Insurise.Application.Features.Production.Fees.Queries.GetFeesDetail;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Fees.Queries.GetFeesList;

public class GetFeesListQueryHandler : IRequestHandler<GetFeesListQuery, List<FeesDto>>
{
    private readonly IRepository<Fee> _feesRepository;
    private readonly IMapper _mapper;

    public GetFeesListQueryHandler(IMapper mapper, IRepository<Fee> feesRepository)
    {
        _mapper = mapper;
        _feesRepository = feesRepository;
    }

    public async Task<List<FeesDto>> Handle(GetFeesListQuery request, CancellationToken cancellationToken)
    {
        var allFees = await _feesRepository.ListAsync();
        return _mapper.Map<List<FeesDto>>(allFees);
    }
}