using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.TiersCompanies.Commands.DeleteTiersCompany;

public class DeleteTiersCompanyCommandHandler : IRequestHandler<DeleteTiersCompanyCommand>
{
    private readonly IRepository<TiersCompany> _tiersCompanyRepository;

    public DeleteTiersCompanyCommandHandler(IRepository<TiersCompany> tiersCompanyRepository)
    {
        _tiersCompanyRepository = tiersCompanyRepository;
    }

    public async Task<Unit> Handle(DeleteTiersCompanyCommand request, CancellationToken cancellationToken)
    {
        var tiersCompanyToDelete =
            await _tiersCompanyRepository.GetByIdAsync(request.TiersCompanyId, cancellationToken);

        // if (tiersCompanyToDelete == null) throw new NotFoundException("TiersCompany", request.TiersCompanyId);

        await _tiersCompanyRepository.DeleteAsync(tiersCompanyToDelete, cancellationToken);

        return Unit.Value;
    }
}