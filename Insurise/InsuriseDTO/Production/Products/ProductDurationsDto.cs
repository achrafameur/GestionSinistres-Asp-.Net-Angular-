using InsuriseDTO.Common;

namespace InsuriseDTO.Production.Products;

public class ProductDurationsDto
{ 
    public ProductDurationsDto(int? id, string product, int? productId, string duration, int? durationId, bool actif,
        List<ProductDurationProportionDto> proportions
    )
    {
        Id = id.HasValue?id.Value:0;
        Product = product; 
        ProductId = productId.HasValue ? productId.Value : 0;
        Duration = duration; 
        DurationId = durationId.HasValue ? durationId.Value : 0;
        Actif = actif;
        Proportions = proportions;
    }

    public int Id { get; set; }
    public string Product { get; set; }
    public int ProductId { get; set; }
    public string Duration { get; set; }
    public int DurationId { get; set; }
    public bool Actif { get; set; }
    public List<ProductDurationProportionDto> Proportions { get; set; }
}
