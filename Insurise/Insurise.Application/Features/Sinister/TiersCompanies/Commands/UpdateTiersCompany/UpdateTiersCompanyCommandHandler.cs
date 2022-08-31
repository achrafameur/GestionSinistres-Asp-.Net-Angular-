using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.TiersCompanies.Commands.UpdateTiersCompany;

public class UpdateTiersCompanyCommandHandler : IRequestHandler<UpdateTiersCompanyCommand>
{
    private readonly IRepository<TiersCompany> _repository;
    private readonly IMapper _mapper;

    public UpdateTiersCompanyCommandHandler(IMapper mapper, IRepository<TiersCompany> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateTiersCompanyCommand request, CancellationToken cancellationToken)
    {
        var tiersCompanyToUpdate =await _repository.GetByIdAsync(request.TiersCompanyId, cancellationToken);

        if (tiersCompanyToUpdate == null) throw new TierCompanyNotFoundException(request.TiersCompanyId);

        _mapper.Map(request, tiersCompanyToUpdate, typeof(UpdateTiersCompanyCommand), typeof(TiersCompany));

        await _repository.UpdateAsync(tiersCompanyToUpdate, cancellationToken);

        return Unit.Value;
    }
}