using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.Core.Specifications.Filters.Commun.Proportion;
using Insurise.Core.Specifications.Filters.Product;
using Insurise.Core.Specifications.Products;
using Insurise.SharedKernel.Interfaces;
using InsuriseDTO.Common;
using InsuriseDTO.Production.Products;
using MediatR;

namespace Insurise.Application.Features.Production.Product.Queries.GetProductDurationDetailById;

public class GetProductDurationByIdDetailQueryHandler : IRequestHandler<GetProductDurationByIdDetailQuery, ProductDurationsDto>
{
    private readonly IRepository<ProductDuration> _productDurationRepository;
    private readonly IRepository<Proportion> _proportionRepository;
    private readonly IMapper _mapper;

    public GetProductDurationByIdDetailQueryHandler(IMapper mapper, IRepository<ProductDuration> productDurationRepository, IRepository<Proportion> proportionRepository)
    {
        _mapper = mapper;
        _productDurationRepository = productDurationRepository;
        _proportionRepository = proportionRepository;
    }
 
    public async Task<ProductDurationsDto?> Handle(GetProductDurationByIdDetailQuery request, CancellationToken cancellationToken)
    {
        if (request.Id.HasValue && request.Id.Value != 0)
        {
            var filter = new ProductDurationFilter
            {
                Id = request.Id.Value,
                LoadChildren = true,
                Children = new List<string> { "Proportions", "Proportions.Proportion", "Product", "Duration" },
                IsPagingEnabled = false
            };
            var ProductDurationsByProductIdSpec = new ProductDurationSpecSingleResult(filter);
            var ProductDurationsByProduct = await _productDurationRepository.GetBySpecAsync(ProductDurationsByProductIdSpec);

            var filterProportion = new ProportionFilter
            {
                LoadChildren = true,
                Children = new List<string> { "ProportionDurations", "ProportionDurations.ProductDuration", "ProportionDurations.ProductDuration.Duration" },
                IsPagingEnabled = false
            };
            var spec = new ProportionSpec(filterProportion);
            var proportions = await _proportionRepository.ListAsync(spec, cancellationToken);

            var allproportions = proportions.Select(item =>
                 new ProductDurationProportionDto
                 {
                     IsChecked = item.ProportionDurations.Any(x => x.ProductDurationId == ProductDurationsByProduct.Id && !x.IsDeleted),
                     Id = (int)(item.ProportionDurations.Any(x => x.ProductDurationId == ProductDurationsByProduct.Id && !x.IsDeleted) ? item.ProportionDurations.FirstOrDefault(x => x.ProductDurationId == ProductDurationsByProduct.Id && !x.IsDeleted)?.Id : 0),
                     Title = item.ProportionDurations.Any(x => x.ProductDurationId == ProductDurationsByProduct.Id && !x.IsDeleted) ? item.ProportionDurations.FirstOrDefault(x => x.ProductDurationId == ProductDurationsByProduct.Id && !x.IsDeleted)?.title : item.Title,
                     Proportion = item.ProportionDurations.Any(x => x.ProductDurationId == ProductDurationsByProduct.Id && !x.IsDeleted) ? item.ProportionDurations.FirstOrDefault(x => x.ProductDurationId == ProductDurationsByProduct.Id && !x.IsDeleted).Proportion.Title.ToString() : item.Title,
                     ProportionId = item.ProportionDurations.Any(x => x.ProductDurationId == ProductDurationsByProduct.Id && !x.IsDeleted) ? item.ProportionDurations.FirstOrDefault(x => x.ProductDurationId == ProductDurationsByProduct.Id && !x.IsDeleted).ProportionId : item.Id,
                     ProductDuration = item.ProportionDurations.Any(x => x.ProductDurationId == ProductDurationsByProduct.Id && !x.IsDeleted) ? item.ProportionDurations.FirstOrDefault(x => x.ProductDurationId == ProductDurationsByProduct.Id && !x.IsDeleted).ProductDuration.Duration.Title.ToString() : item.Title,
                     ProductDurationId = ProductDurationsByProduct.Id
                 }).ToList();
            var productDurationsById = _mapper.Map<ProductDurationsDto>(ProductDurationsByProduct);
            productDurationsById.Proportions = allproportions;
            return productDurationsById;
        }
        else
        { 
            var filterProportion = new ProportionFilter
            {
                LoadChildren = true,
                Children = new List<string> { "ProportionDurations", "ProportionDurations.ProductDuration", "ProportionDurations.ProductDuration.Duration" },
                IsPagingEnabled = false
            };
            var spec = new ProportionSpec(filterProportion);
            var proportions = await _proportionRepository.ListAsync(spec, cancellationToken);

            var allproportions = proportions.Select(item =>
                 new ProductDurationProportionDto
                 {
                     IsChecked =false,
                     Id =0,
                     Title = item.Title,
                     Proportion = item.Title,
                     ProportionId =   item.Id,
                     ProductDuration =  "",
                     ProductDurationId =0
                 }).ToList();
           
            var productDuration = new ProductDurationsDto(null, "", null, "", null, true, allproportions);
            return productDuration;
        }
       
    }
}
