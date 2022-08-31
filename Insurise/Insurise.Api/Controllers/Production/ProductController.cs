// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using Ardalis.Result;
using Insurise.Api.Web.Extensions;
using Insurise.Application.Features.Production.Product.Commands.AddPackage;
using Insurise.Application.Features.Production.Product.Commands.AddProduct;
using Insurise.Application.Features.Production.Product.Commands.DeleteProduct;
using Insurise.Application.Features.Production.Product.Commands.DeleteProductDuration;
using Insurise.Application.Features.Production.Product.Commands.DeleteProductFee;
using Insurise.Application.Features.Production.Product.Commands.DeleteProductShop;
using Insurise.Application.Features.Production.Product.Commands.DeleteProductWarranty;
using Insurise.Application.Features.Production.Product.Commands.SetDurations;
using Insurise.Application.Features.Production.Product.Commands.SetFees;
using Insurise.Application.Features.Production.Product.Commands.SetShops;
using Insurise.Application.Features.Production.Product.Commands.setWarranties;
using Insurise.Application.Features.Production.Product.Commands.UpdateProduct;
using Insurise.Application.Features.Production.Product.Commands.UpdateProductFee;
using Insurise.Application.Features.Production.Product.Commands.UpdateProductWarranty;
using Insurise.Application.Features.Production.Product.Queries.GetDurationsDetail;
using Insurise.Application.Features.Production.Product.Queries.GetProductDetail;
using Insurise.Application.Features.Production.Product.Queries.GetProductDurationDetailById;
using Insurise.Application.Features.Production.Product.Queries.GetProductDurationsDetail;
using Insurise.Application.Features.Production.Product.Queries.GetProductFeesDetail;
using Insurise.Application.Features.Production.Product.Queries.GetProductShopsDetail;
using Insurise.Application.Features.Production.Product.Queries.GetProductShopsList;
using Insurise.Application.Features.Production.Product.Queries.GetProductsList;
using Insurise.Application.Features.Production.Product.Queries.GetWarrantiesDetail;
using Insurise.Infrastructure.Web.Rest.Utilities;
using InsuriseDTO.Production.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Production;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private const string EntityName = "product";
    private readonly ILogger<ProductController> _log;
    private readonly IMediator _mediator;

    public ProductController(ILogger<ProductController> log, IMediator mediator)
    {
        _log = log;
        _mediator = mediator;
    }

    #region Product -------------------------------

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> Get([FromQuery] ProductFilterDto filter)
    {
        // Here you can decide if you want the collections as well

        filter.LoadChildren = true;
        filter.IsPagingEnabled = true;
        var result = await _mediator.Send(new GetProductListQuery(filter));
        var pagedInfo = ((PagedResult<List<ProductDto>>) result).PagedInfo;
        var rsltok = Ok(result.Value).WithHeaders(pagedInfo.GeneratePaginationHttpHeaders());
        return rsltok;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<ProductDto>>> GetById(int id)
    {
        var productDetail = new GetProductDetailQuery(id);
        return Ok(await _mediator.Send(productDetail));
    }

    // POST api/<ProductController>
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] AddProductCommand addProductCommand)
    {
        _log.LogDebug($"REST request to save {EntityName}  : {addProductCommand}", EntityName,
            addProductCommand.ToString());
        var response = await _mediator.Send(addProductCommand);
        return Ok(response);
    }

    // PUT api/<ProductController>/5
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
    {
        await _mediator.Send(updateProductCommand);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteProductCommand(id));
        return NoContent();
    }

    #endregion

    #region Product Package-------------------------------

    [HttpPost]
    [Route("CreatePackage")]
    public async Task<ActionResult> CreatePackage([FromBody] AddPackageCommand package)
    {
        var response = await _mediator.Send(package);
        return Ok(response);
    }

    #endregion

    #region Product Warranties-------------------------------

    //Get Warranties By ProductId
    [HttpGet]
    [Route("GetWarrantiesByProductId/{id:int}")]
    public async Task<ActionResult> GetWarrantiesByProductId(int id)
    {
        var warranties = await _mediator.Send(new GetWarrantiesDetailQuery(id));
        return Ok(warranties);
    }

    //Set Warranties  
    [HttpPost]
    [Route("setWarranties")]
    public async Task<ActionResult> SetWarranties([FromBody] SetWarrantiesCommand warrantiesCommand)
    {
        var response = await _mediator.Send(warrantiesCommand);
        return Ok(response);
    }

    // PUT api/<ProductController>/UpdateProductWarranty
    [HttpPut("UpdateProductWarranty")]
    public async Task<ActionResult> UpdateProductWarranty(
        [FromBody] UpdateProductWarrantyCommand updateProductWarrantyCommand)
    {
        await _mediator.Send(updateProductWarrantyCommand);
        return Ok();
    }

    [HttpDelete("DeleteProductWarrantyById/{id:int}/{productId:int}")]
    public async Task<ActionResult> DeleteProductWarranty(int id, int productId)
    {
        await _mediator.Send(new DeleteProductWarantyCommand(id, productId));
        return NoContent();
    }

    #endregion

    #region Product Fees-------------------------------

    //Get Warranties By ProductId
    [HttpGet("GetFeesByProductId/{id:int}")]
    public async Task<ActionResult> GetFeesByProductId(int id)
    {
        var fees = await _mediator.Send(new GetProductFeesDetailQuery(id));
        return Ok(fees);
    }

    //Set Warranties  
    [HttpPost("SetFees")]
    public async Task<ActionResult> SetFees([FromBody] SetFeesCommand feesCommand)
    {
        var response = await _mediator.Send(feesCommand);
        return Ok(response);
    }

    // PUT api/<ProductController>/UpdateProductFee
    [HttpPut("UpdateProductFee")]
    public async Task<ActionResult> UpdateProductFee([FromBody] UpdateProductFeeCommand updateProductFeeCommand)
    {
        await _mediator.Send(updateProductFeeCommand);
        return Ok();
    }

    [HttpDelete("DeleteProductFeeById/{id:int}/{productId:int}")]
    public async Task<ActionResult> DeleteProductFee(int id, int productId)
    {
        await _mediator.Send(new DeleteProductFeeCommand(id, productId));
        return NoContent();
    }

    #endregion

    #region Product Durations-------------------------------

    //Get Durations By ProductId
    [HttpGet("GetDurationsByProductId/{id:int}")]
    public async Task<ActionResult> GetDurationsByProductId(int id)
    {
        _log.LogDebug($"Get Durations By ProductId");
        var dtos = await _mediator.Send(new GetDurationsDetailQuery(id));
        return Ok(dtos);
    }

    [HttpGet(("GetProductDurationsListByProductId/{id:int}"))]
    public async Task<ActionResult> GetProductDurationsListByProductId(int id)
    {
        var shops = await _mediator.Send(new GetProductDurationsDetailQuery(id));
        return Ok(shops);
    }

    [HttpGet("GetProductDurationById/{id:int}")]
    public async Task<ActionResult> GetProductDurationById(int? id)
    {
        var shops = await _mediator.Send(new GetProductDurationByIdDetailQuery(id));
        return Ok(shops);
    }

    //Set Durations  
    [HttpPost("SetDurations")]
    public async Task<ActionResult> SetDurations([FromBody] SetDurationsCommand durationsCommand)
    {
        var response = await _mediator.Send(durationsCommand);
        return Ok(response);
    }

    [HttpDelete("DeleteProductDuration/{id:int}")]
    public async Task<ActionResult> DeleteProductDuration(int id)
    {
        await _mediator.Send(new DeleteProductDurationCommand(id));
        return NoContent();
    }

    #endregion

    #region Product Shops-------------------------------

    //Get Warranties By ProductId
    [HttpGet("GetShopsByProductId/{id:int}")]
    public async Task<ActionResult> GetShopsByProductId(int id)
    {
        var shops = await _mediator.Send(new GetProductShopsDetailQuery(id));
        return Ok(shops);
    }

    [HttpGet("GetProductShopsListByProductId/{id:int}")]
    public async Task<ActionResult> GetProductShopsListByProductId(int id)
    {
        var shops = await _mediator.Send(new GetProductShopsListQuery(id));
        return Ok(shops);
    }

    //Set Warranties  
    [HttpPost("SetShops")]
    public async Task<ActionResult> SetShops([FromBody] SetShopsCommand shopCommand)
    {
        var response = await _mediator.Send(shopCommand);
        return Ok(response);
    }

    [HttpDelete("DeleteProductShopById/{id:int}")]
    public async Task<ActionResult> DeleteProductShop(int id)
    {
        await _mediator.Send(new DeleteProductShopCommand(id));
        return NoContent();
    }

    #endregion
}
