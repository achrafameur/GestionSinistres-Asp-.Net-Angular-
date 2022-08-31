using AutoMapper; 
using Insurise.Core.Entities.Common;
using Insurise.Core.Entities.Production.ProductAggregate;  
using Insurise.Core.Specifications.Products;
using Insurise.SharedKernel.Interfaces; 
using MediatR;
using PackageEntity = Insurise.Core.Entities.Production.ProductAggregate;
using Unit = MediatR.Unit; 
using InsuriseDTO.Common;
using Ardalis.GuardClauses;
using Insurise.Core.Specifications.Filters.Product;

namespace Insurise.Application.Features.Production.Product.Commands.SetDurations;

public class SetDurationsCommandHandler : IRequestHandler<SetDurationsCommand>
{
    private readonly IRepository<PackageEntity.Product> _repository;
    private readonly IRepository<ProductDuration> _productDurationrepository;
    private readonly IMapper _mapper;

    public SetDurationsCommandHandler(IMapper mapper, IRepository<PackageEntity.Product> repository, IRepository<ProductDuration> productDurationrepository)
    {
        _mapper = mapper;
        _repository = repository;
        _productDurationrepository =  productDurationrepository;
    }

    public async Task<Unit> Handle(SetDurationsCommand request, CancellationToken cancellationToken)
    { 
        var filter = new ProductFilter
        {
            ProductId = request.ProductId,
            LoadChildren = true,
            Children = new List<string> { "ProductDurations", "ProductDurations.Proportions" },
            IsPagingEnabled = false
        };
        var productSpec = new ProductSpecSingleResult(filter);
        var productToUpdate = await _repository.GetBySpecAsync(productSpec, cancellationToken);
        Guard.Against.Null(productToUpdate, nameof(productToUpdate)); 
      
        if (request.ProductDurationId.HasValue && request.ProductDurationId.Value==0)
        {
            ProductDuration? productDurationToAdd = productToUpdate.ProductDurations.FirstOrDefault(x => x.DurationId == request.DurationId && x.ProductId==request.ProductId);
            if (productDurationToAdd == null)
            {
                productDurationToAdd = new ProductDuration(request.ProductId, request.DurationId, true); 
            }
            else
            {
                productDurationToAdd.IsDeleted = false;
            }
            var productDurationProportionToAdd = new List<ProductDurationProportion>();
            foreach (var productDurationProportionDto in request.Proportions)
            {
                productDurationProportionDto.ProductDurationId = productDurationToAdd.Id;
                var elementToAdd = productDurationToAdd.Proportions.FirstOrDefault(x =>x.ProductDurationId == productDurationProportionDto.ProductDurationId && x.ProportionId == productDurationProportionDto.ProportionId);
                if (elementToAdd == null)
                {
                    var productDurationProportion = _mapper.Map<ProductDurationProportion>(productDurationProportionDto);
                    productDurationProportionToAdd.Add(productDurationProportion);
                }
                else
                { 
                    elementToAdd.IsDeleted = false;
                }
            } 
            productDurationToAdd.AddProductDurationProportion(productDurationProportionToAdd); 
            if (productDurationToAdd.Id == 0)
            { 
                productToUpdate.AddProductDuration(productDurationToAdd);
            }
        }
        else
        { 
            ProductDuration? productDurationToUpdate = productToUpdate.ProductDurations.FirstOrDefault(x =>x.Id== request.ProductDurationId.Value);  
            var productDurationProportionToRemove = (from productDurationProportion in productDurationToUpdate.Proportions
                                                     where request.Proportions.Where(x => x.Id == productDurationProportion.Id).FirstOrDefault() == null
                                                     select productDurationProportion).ToList();
            productDurationToUpdate.RemoveProductDurationsProportions(productDurationProportionToRemove);



            var lstProductDurationProportion = _mapper.Map<List<ProductDurationProportion>>(request.Proportions);
            var productDurationProportionToAdd = new List<ProductDurationProportion>();
            foreach (var (productDurationProportionDto, elementToUpdate) in from productDurationProportionDto in request.Proportions
                                                                            let elementToUpdate = productDurationToUpdate.Proportions.FirstOrDefault(x => x.Id == productDurationProportionDto.Id)
                                                                            select (productDurationProportionDto, elementToUpdate))
            {
                if (elementToUpdate == null)
                {
                    var productDurationProportion = _mapper.Map<ProductDurationProportion>(productDurationProportionDto);
                    productDurationProportionToAdd.Add(productDurationProportion);
                }
                else
                {
                    _mapper.Map(productDurationProportionDto, elementToUpdate, typeof(ProductDurationProportionDto), typeof(ProductDurationProportion));
                    elementToUpdate.IsDeleted = false;
                }
            }

            productDurationToUpdate.AddProductDurationProportion(productDurationProportionToAdd);
            if (!productDurationToUpdate.Proportions.Any(x => !x.IsDeleted))
            {
                productDurationToUpdate.IsDeleted = true;
            }
            else
            {
                productDurationToUpdate.IsDeleted = false;
            }
        } 
        await _repository.UpdateAsync(productToUpdate, cancellationToken);
        return Unit.Value;
    }
}
