using AutoMapper;
using Insurise.Application.Features.Sinister.TiersCompanies.Queries.GetTiersCompanyDetail;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.TiersCompanies.Queries.GetTiersCompaniesList;

public class GetTiersCompaniesListQueryHandler : IRequestHandler<GetTiersCompaniesListQuery, List<TiersCompanyDto>>
{
    private readonly IRepository<TiersCompany> _TiersCompanyRepository;
    private readonly IMapper _mapper;

    public GetTiersCompaniesListQueryHandler(IMapper mapper, IRepository<TiersCompany> TiersCompanyRepository)
    {
        _mapper = mapper;
        _TiersCompanyRepository = TiersCompanyRepository;
    }

    public async Task<List<TiersCompanyDto>> Handle(GetTiersCompaniesListQuery request,
        CancellationToken cancellationToken)
    {
        var allTiersCompanies = await _TiersCompanyRepository.ListAsync(cancellationToken);
        return _mapper.Map<List<TiersCompanyDto>>(allTiersCompanies);
    }
}