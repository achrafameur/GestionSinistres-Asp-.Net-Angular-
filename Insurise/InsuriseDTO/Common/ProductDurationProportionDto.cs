namespace InsuriseDTO.Common;

public class ProductDurationProportionDto
{
    public ProductDurationProportionDto()
    {

    }
    public ProductDurationProportionDto(int id, string title, string proportion, int proportionId, string productDuration, int productDurationId )
    {
        Id = id;
        Title = title;
        Proportion = proportion;
        ProportionId = proportionId;
        ProductDuration = productDuration;
        ProductDurationId = productDurationId; 
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Proportion { get; set; }
    public int ProportionId { get; set; }
    public string ProductDuration { get; set; }
    public int ProductDurationId { get; set; }
    public bool IsChecked { get; set; } = false;
}
