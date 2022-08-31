namespace Insurise.Application.Features.Common.Branches.Queries.GetBranchDetail;

public class BranchDto
{
    public BranchDto(int branchId, string title, string description, int? parentId, string branchParent)
    {
        BranchId = branchId;
        Title = title;
        Description = description;
        ParentId = parentId;
        BranchParent = branchParent;
    }

    public int BranchId { get; }
    public string Title { get; }
    public string Description { get; }
    public int? ParentId { get; set; }
    public string BranchParent { get; set; }
}