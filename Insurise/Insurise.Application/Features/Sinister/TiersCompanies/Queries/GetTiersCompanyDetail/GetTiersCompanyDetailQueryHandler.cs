using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.TiersCompanies.Queries.GetTiersCompanyDetail;

public class GetTiersDetailQueryHandler : IRequestHandler<GetTiersCompanyDetailQuery, TiersCompanyDto>
{
    private readonly IRepository<TiersCompany> _TiersRepository;
    private readonly IMapper _mapper;

    public GetTiersDetailQueryHandler(IMapper mapper, IRepository<TiersCompany> TiersRepository)
    {
        _mapper = mapper;
        _TiersRepository = TiersRepository;
    }

    public async Task<TiersCompanyDto> Handle(GetTiersCompanyDetailQuery request, CancellationToken cancellationToken)
    {
        var tiersCompany = await _TiersRepository.GetByIdAsync(request.TiersCompanyId);
        var returnedTiersCompany = _mapper.Map<TiersCompanyDto>(tiersCompany);

        return returnedTiersCompany;
    }
}