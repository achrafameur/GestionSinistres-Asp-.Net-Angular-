using MediatR;

namespace Insurise.Application.Features.Sinister.TiersCompanies.Commands.DeleteTiersCompany;

public class DeleteTiersCompanyCommand : IRequest
{
    public DeleteTiersCompanyCommand(int tiersCompanyId)
    {
        TiersCompanyId = tiersCompanyId;
    }

    public int TiersCompanyId { get; }
}