namespace InsuriseDTO.Production.Products;

public class ProductWarrantyDto
{
    public ProductWarrantyDto(int id, bool mandatory, int rank, int productId, int warrantyId, string warranty,
        string product)
    {
        Id = id;
        Mandatory = mandatory;
        Rank = rank;
        ProductId = productId;
        WarrantyId = warrantyId;
        Warranty = warranty;
        Product = product;
    }
    public int Id { get; set; } 
    public bool Mandatory { get; set; }
    public int Rank { get; set; }
    public string Product { get; set; }
    public int ProductId { get; set; }
    public string Warranty { get; set; }
    public int WarrantyId { get; set; }
}
