using MediatR;

namespace Insurise.Application.Features.Common.Branches.Commands.DeleteBranch;

public class DeleteBranchCommand : IRequest
{
    public DeleteBranchCommand(int branchId)
    {
        BranchId = branchId;
    }

    public int BranchId { get; }
}