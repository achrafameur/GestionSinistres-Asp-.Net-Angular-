using MediatR;

namespace Insurise.Application.Features.Common.Branches.Commands.UpdateBranch;

public class UpdateBranchCommand : IRequest
{
    public UpdateBranchCommand(int branchId, string title, string description, int? parentId)
    {
        BranchId = branchId;
        Title = title;
        Description = description;
        ParentId = parentId;
    }

    public int BranchId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int? ParentId { get; private set; }
}