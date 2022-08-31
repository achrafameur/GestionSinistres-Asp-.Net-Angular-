using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using Unit = MediatR.Unit;

namespace Insurise.Application.Features.Common.Natures.Commands.DeleteNature;

public class DeleteNatureCommandHandler : IRequestHandler<DeleteNatureCommand>
{
    private readonly IRepository<Nature> _natureRepository;

    public DeleteNatureCommandHandler(IRepository<Nature> natureRepository)
    {
        _natureRepository = natureRepository;
    }

    public async Task<Unit> Handle(DeleteNatureCommand request, CancellationToken cancellationToken)
    {
        var natureToDelete = await _natureRepository.GetByIdAsync(request.NatureId, cancellationToken);
        if (natureToDelete == null) throw new NatureNotFoundException(request.NatureId);

        await _natureRepository.DeleteAsync(natureToDelete, cancellationToken);
        return Unit.Value;
    }
}