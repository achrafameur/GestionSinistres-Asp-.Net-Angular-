using Ardalis.GuardClauses;
using Insurise.Core.Entities.Common;
using Insurise.Core.Events;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Production.ProductAggregate;
public class Product : BaseEntity<int> 
{

    private readonly List<ProductShop> _productShops;
    public virtual IEnumerable<ProductShop> ProductShops => _productShops.AsReadOnly();

    private readonly List<ProductTax> _productTaxes;
    public virtual IEnumerable<ProductTax> ProductTaxes => _productTaxes.AsReadOnly();

    private readonly List<ProductWarranty> _productWarranties;
    public virtual IEnumerable<ProductWarranty> ProductWarranties => _productWarranties.AsReadOnly();

    private readonly List<ProductFee> _productFees;
    public virtual IEnumerable<ProductFee> ProductFees => _productFees.AsReadOnly();

    private readonly List<ProductDuration> _productDurations;
    public virtual IEnumerable<ProductDuration> ProductDurations => _productDurations.AsReadOnly();

    private readonly List<Product> _children;
    public virtual IEnumerable<Product> Children => _children.AsReadOnly();

    private readonly List<Product> _productParent;
    public virtual IEnumerable<Product> ProductParent => _productParent.AsReadOnly();


    public Product(string title, string? description, DateTime startDate, DateTime? expirationDate, double defaultDiscount, int branchId, string code, string? fileName, string? image)
    {
        Title = title;
        Description = description;
        StartDate = startDate;
        ExpirationDate = expirationDate;
        DefaultDiscount = defaultDiscount;
        BranchId = branchId;
        Code = code;
        FileName = fileName;
        Image = image;
        _productTaxes = new List<ProductTax>();
        _productWarranties = new List<ProductWarranty>();
        _productFees = new List<ProductFee>();
        _productDurations = new List<ProductDuration>();
        _children = new List<Product>();
        _productParent = new List<Product>();
        _productShops = new List<ProductShop>();

    }

    public string Title { get; protected set; }
    public string? Description { get; protected set; }
    public string Code { get; protected set; }
    public DateTime StartDate { get; protected set; }
    public DateTime? ExpirationDate { get; protected set; }
    public double DefaultDiscount { get; protected set; }
    public int BranchId { get; protected set; }
    public virtual Branch? Branch { get; protected set; }
    public string? FileName { get; set; }
    public string? Image { get; set; }
    public bool IsActive => StartDate <= DateTime.Now && ExpirationDate >= DateTime.Now;

    internal void SetProductBranch(Branch branch) => Branch = branch;

    public void DeleteProduct()
    {
        IsDeleted =true;
    }
    #region ProductWarranties
    public void AddProductWarranties(List<ProductWarranty> productWarranties)
    {
        _productWarranties.AddRange(productWarranties);
        foreach (var productWarranty in productWarranties)
        {
            var newWarrantyAddedEvent = new ProductWarrantiesChosenEvent(this, productWarranty.Warranty);
            Events.Add(newWarrantyAddedEvent);
        }
    }
    public void RemoveProductWarranties(List<ProductWarranty> productWarranties)
    {
        foreach (var productWarranty in productWarranties)
        {
            Guard.Against.Null(productWarranty, nameof(productWarranty));
            productWarranty.IsDeleted = true;
            productWarranty.Rank = 0;
            var newWarrantyRemoveEvent = new ProductWarrantiesRemovedEvent(this, productWarranty.Warranty);
            Events.Add(newWarrantyRemoveEvent);
        }
    }
    public void ReorderProductWarranties()
    {
        int rank = 1;
        foreach (var productWarranty in _productWarranties.Where(x => !x.IsDeleted))
        {
            productWarranty.Rank = rank;
            rank++;
        }
    }
    #endregion

    #region ProductFees
    public void AddProductFees(List<ProductFee> productFees)
    {
        _productFees.AddRange(productFees);

    }
    public void RemoveProductFees(List<ProductFee> productFees)
    {
        foreach (var productFee in productFees)
        {
            productFee.IsDeleted = true;
        }
    }
    public void ReorderProductFees()
    {
        int rank = 1;
        foreach (var productFee in _productFees.Where(x => !x.IsDeleted))
        {
            productFee.Rank = rank;
            rank++;
        }
    }
    #endregion

    #region ProductTaxes
    public void ChooseTaxes(List<ProductTax> productTax)
    {
        _productTaxes.AddRange(productTax);

    }
    #endregion

    #region ProductDurations
    public void AddProductDuration(ProductDuration productDuration)
    {
        _productDurations.Add(productDuration); 
    }
 

    #endregion

    #region ProductShops 
    public void AddProductShops(List<ProductShop> productShops)
    {
        _productShops.AddRange(productShops);

    }
    public void RemoveProductShops(List<ProductShop> productShops)
    {
        foreach (var productShop in productShops)
        {
            productShop.IsDeleted = true;
        }
    }
 
    #endregion

    #region ProductPackage
    public void AddProductChild(List<Product> productChild)
    {
        _children.AddRange(productChild);
    }

    #endregion
}


