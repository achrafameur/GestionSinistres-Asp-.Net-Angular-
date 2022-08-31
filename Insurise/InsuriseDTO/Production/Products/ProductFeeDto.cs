namespace InsuriseDTO.Production.Products;

public class ProductFeeDto
{
    public ProductFeeDto(int id, int rank, int productId, int feesId, string product, string fees)
    {
        Id = id;
        Product = product;
        ProductId = productId;
        Fees = fees;
        FeesId = feesId;
        Rank = rank;
    }

    public int Id { get; set; } 
    public int Rank { get; set; }
    public string Product { get; set; }
    public int ProductId { get; set; }
    public string Fees { get; set; }
    public int FeesId { get; set; }
}
