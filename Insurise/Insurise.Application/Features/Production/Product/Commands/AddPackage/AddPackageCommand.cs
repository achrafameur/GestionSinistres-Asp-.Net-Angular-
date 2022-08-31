using Insurise.Application.Features.Production.Product.Commands.AddProduct;
using MediatR;

namespace Insurise.Application.Features.Production.Product.Commands.AddPackage;

public class AddPackageCommand : AddProductCommand, IRequest<int>
{
    public AddPackageCommand(string title, string description, DateTime startDate, DateTime? expirationDate,
        double defaultDiscount, int? branchId, string code, int? certificateId, string? fileName, string? image,
        List<int>? selectedProducts) : base(title, description, startDate, expirationDate, defaultDiscount, branchId,
        code, certificateId, fileName, image)
    {
        this.selectedProducts = selectedProducts;
    }

    public List<int>? selectedProducts { get; set; }
}