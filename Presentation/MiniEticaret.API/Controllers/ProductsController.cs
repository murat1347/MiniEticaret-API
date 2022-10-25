using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniEticaret.Application.Abstractions.Storage;
using MiniEticaret.Application.Features.Commands.Product.CreateProduct;
using MiniEticaret.Application.Features.Commands.Product.RemoveProduct;
using MiniEticaret.Application.Features.Commands.Product.UpdateProduct;
using MiniEticaret.Application.Features.Commands.ProductImageFile.ChangeShowcaseImage;
using MiniEticaret.Application.Features.Commands.ProductImageFile.RemoveProduct;
using MiniEticaret.Application.Features.Commands.ProductImageFile.UploadImageFile;
using MiniEticaret.Application.Features.Queries.Product.GetAllProduct;
using MiniEticaret.Application.Features.Queries.Product.GetByIdProduct;
using MiniEticaret.Application.Features.Queries.ProductImageFile.GetProductImages;
using MiniEticaret.Application.Repositories;
using MiniEticaret.Application.ViewModels.Products;
using MiniEticaret.Domain.Entities;
using MiniEticaret.Persistence.Repositories;
using MiniEticaret.Persistence.Repositories.File;
using MiniEticaret.Persistence.Repositories.InvoiceFile;
using MiniEticaret.Persistence.Repositories.ProductImageFile;
using System.Net;

namespace MiniEticaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }
        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse response = await _mediator.Send(updateProductCommandRequest);
            return Ok();
        }
        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveProductCommandRequest removeProductCommandRequest)
        {
            RemoveProductCommandResponse response = await _mediator.Send(removeProductCommandRequest);
            return Ok();
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Upload([FromQuery] UploadProductImageCommandRequest uploadProductImageCommandRequest)
        {
            uploadProductImageCommandRequest.Files = Request.Form.Files;
            UploadProductImageCommandResponse response = await _mediator.Send(uploadProductImageCommandRequest);
            return Ok();
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProductImages([FromRoute] GetProductImagesQueryRequest getProductImagesQueryRequest)
        {
            List<GetProductImagesQueryResponse> response = await _mediator.Send(getProductImagesQueryRequest);
            return Ok(response);
        }
        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] RemoveProductImageCommandRequest removeProductImageCommandRequest, [FromQuery] string imageId)
        {
            removeProductImageCommandRequest.ImageId = imageId;
            RemoveProductImageCommandResponse response = await _mediator.Send(removeProductImageCommandRequest);
            return Ok();
        }
        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> ChangeShowcaseImage([FromQuery] ChangeShowcaseImageCommandRequest changeShowcaseImageCommandRequest)
        {
            ChangeShowcaseImageCommandResponse response = await _mediator.Send(changeShowcaseImageCommandRequest);
            return Ok(response);
        }


    }
}