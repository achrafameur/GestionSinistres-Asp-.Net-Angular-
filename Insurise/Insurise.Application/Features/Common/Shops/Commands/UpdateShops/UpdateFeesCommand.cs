using MediatR;

namespace Insurise.Application.Features.Common.Shops.Commands.UpdateShops;

public class UpdateShopsCommand : IRequest
{
    public UpdateShopsCommand(int shopId, string title, int type, string code, string description, int? departmentId)
    {
        ShopId = shopId;
        Title = title;
        Type = type;
        Code = code;
        Description = description;
        DepartmentId = departmentId;
    }

    public int ShopId { get; set; }
    public string Title { get; set; }
    public int Type { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public int? DepartmentId { get; set; }
}