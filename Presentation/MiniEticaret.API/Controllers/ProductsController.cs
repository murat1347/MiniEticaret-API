﻿using Microsoft.AspNetCore.Mvc;
using MiniEticaret.Application.Abstractions.Storage;
using MiniEticaret.Application.Repositories;
using MiniEticaret.Application.RequestParameters;
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
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        readonly IFileWriteRepository _fileWriteRepository;
        readonly IFileReadRepository _fileReadRepository;
        readonly IProductImageFileReadRepository _productImageFileReadRepository;
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        readonly IInvoiceFileReadRepository _invoiceFileReadRepository;
        readonly IInvoiceFileWriteRepository _invoiceFileWriteRepository;
        readonly IStorageService _storageService;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IWebHostEnvironment webHostEnvironment, IFileWriteRepository fileWriteRepository, IFileReadRepository fileReadRepository, IProductImageFileReadRepository productImageFileReadRepository, IProductImageFileWriteRepository productImageFileWriteRepository, IInvoiceFileReadRepository invoiceFileReadRepository, IInvoiceFileWriteRepository invoiceFileWriteRepository, IStorageService storageService)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _webHostEnvironment = webHostEnvironment;
            _fileWriteRepository = fileWriteRepository;
            _fileReadRepository = fileReadRepository;
            _productImageFileReadRepository = productImageFileReadRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _invoiceFileReadRepository = invoiceFileReadRepository;
            _invoiceFileWriteRepository = invoiceFileWriteRepository;
            _storageService = storageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Pagination pagination)
        {
            var totalCount = _productReadRepository.GetAll(false).Count();
            var products = _productReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(p => new
            {
                p.Id,
                p.Name,
                p.Stock,
                p.Price,
                p.CreatedDate,
                p.UpdatedDate
            }).ToList();
            return Ok(new
            {
                totalCount,
                products
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id, false));
        }
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Price = (long)model.Price,
                Stock = model.Stock
            });
            await _productWriteRepository.SaveChanges();
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Name = model.Name;
            product.Price = (long)model.Price;
            await _productWriteRepository.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveChanges();
            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            var datas = await _storageService.UploadAsync("resource/files", Request.Form.Files);
            //var datas = await _fileService.UploadAsync("resource/files", Request.Form.Files);
            await _productImageFileWriteRepository.AddRangeAsync(datas.Select(d => new ProductImageFile()
            {
                FileName = d.fileName,
                Path = d.pathOrContainerName,
                Storage = _storageService.StorageName
            }).ToList());
            await _productImageFileWriteRepository.SaveChanges();

            //await _invoiceFileWriteRepository.AddRangeAsync(datas.Select(d => new InvoiceFile()
            //{
            //    FileName = d.fileName,
            //    Path = d.path,
            //    Price = new Random().Next()
            //}).ToList());
            //await _invoiceFileWriteRepository.SaveAsync();

            //await _fileWriteRepository.AddRangeAsync(datas.Select(d => new ETicaretAPI.Domain.Entities.File()
            //{
            //    FileName = d.fileName,
            //    Path = d.path
            //}).ToList());
            //await _fileWriteRepository.SaveAsync();
            return Ok();
        }
    }
}