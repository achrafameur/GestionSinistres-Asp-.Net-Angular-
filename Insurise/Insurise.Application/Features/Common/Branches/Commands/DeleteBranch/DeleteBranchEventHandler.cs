using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using Unit = MediatR.Unit;

namespace Insurise.Application.Features.Common.Branches.Commands.DeleteBranch;

public class DeleteBranchEventHandler : IRequestHandler<DeleteBranchCommand>
{
    private readonly IRepository<Branch> _branchRepository;

    public DeleteBranchEventHandler(IRepository<Branch> branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public async Task<Unit> Handle(DeleteBranchCommand command, CancellationToken cancellationToken)
    {
        var branchToDelete = await _branchRepository.GetByIdAsync(command.BranchId, cancellationToken);

        if (branchToDelete == null) throw new BranchNotFoundException(command.BranchId);

        await _branchRepository.DeleteAsync(branchToDelete, cancellationToken);

        return Unit.Value;
    }
}