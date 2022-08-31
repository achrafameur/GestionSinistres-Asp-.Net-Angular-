namespace InsuriseDTO.Production.Products;

public class ProductShopDto
{
    public ProductShopDto()
    {

    }

    public ProductShopDto(int id, int productId, string product, int shopId, string shop, string shopCode, double reduction, int defaultProduct)
    {
        Id = id;
        ProductId = productId;
        Product = product;
        ShopId = shopId;
        Shop = shop;
        Reduction = reduction;
        DefaultProduct = defaultProduct;
        ShopCode = shopCode;
    }

    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Product { get; set; } 
    public int ShopId { get; set; }
    public string Shop { get; set; }
    public string ShopCode { get; set; }
    public double Reduction { get; set; }
    public int DefaultProduct { get; set; }
    public bool IsChecked { get; set; } = false;
}
