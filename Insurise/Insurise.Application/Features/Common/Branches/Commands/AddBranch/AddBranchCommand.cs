using MediatR;

namespace Insurise.Application.Features.Common.Branches.Commands.AddBranch;

public class AddBranchCommand : IRequest<int>
{
    public AddBranchCommand(string title, string description, int? parentId)
    {
        Title = title;
        Description = description;
        ParentId = parentId;
    }

    public string Title { get; }
    public string Description { get; }
    public int? ParentId { get; }
}