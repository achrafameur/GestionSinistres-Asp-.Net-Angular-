using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.TiersCompanies.Commands.AddTiersCompany;

public class CreateTiersCompanyCommandHandler : IRequestHandler<CreateTiersCompanyCommand, int>
{
    private readonly IRepository<TiersCompany> _TiersCompanyRepository;
    private readonly IMapper _mapper;

    public CreateTiersCompanyCommandHandler(IMapper mapper, IRepository<TiersCompany> TiersCompanyRepository)
    {
        _mapper = mapper;
        _TiersCompanyRepository = TiersCompanyRepository;
    }

    public async Task<int> Handle(CreateTiersCompanyCommand request, CancellationToken cancellationToken)
    {
        var tiersCompany = _mapper.Map<TiersCompany>(request);
        tiersCompany = await _TiersCompanyRepository.AddAsync(tiersCompany, cancellationToken);

        return tiersCompany.Id;
    }
}