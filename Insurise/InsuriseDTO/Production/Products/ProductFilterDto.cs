using InsuriseDTO.Production.Base;

namespace InsuriseDTO.Production.Products;

public class ProductFilterDto : BaseFilterDto
{ 
    public int ProductId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Code { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public double? DefaultDiscount { get; set; }
    public int? BranchId { get; set; }
    public string? Branch { get; set; }
    public string? Image { get; set; }
    public string? FileName { get; set; }
     
    public string? CreationBy { get; set; }
    public DateTime? CreationDate { get; set; }
}
