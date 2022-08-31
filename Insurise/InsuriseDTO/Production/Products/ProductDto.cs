namespace InsuriseDTO.Production.Products;

public class ProductDto
{
    public ProductDto(int productId, string title, string description, DateTime startDate, DateTime? expirationDate,
        double defaultDiscount, int branchId,
        string code, string branch, DateTime? creationDate, string creationBy, string? image, string? fileName)
    {
        ProductId = productId;
        Title = title;
        Description = description;
        StartDate = startDate;
        ExpirationDate = expirationDate;
        DefaultDiscount = defaultDiscount;
        BranchId = branchId;
        Code = code;
        Branch = branch;
        CreationDate = creationDate;
        CreationBy = creationBy;
        Image = image;
        FileName = fileName;
    }

    public int ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public double DefaultDiscount { get; set; }
    public int BranchId { get; set; }
    public string Branch { get; set; }
    public string? Image { get; set; }
    public string? FileName { get; set; }

    public string CreationBy { get; set; }
    public DateTime? CreationDate { get; set; }
}
