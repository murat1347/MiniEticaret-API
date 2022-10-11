using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniEticaret.Application.Repositories;
using MiniEticaret.Domain.Entities;

namespace MiniEticaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task GetProducts()
        {
           await _productWriteRepository.AddRangeAsync(new()
            {
                new(){ Id= Guid.NewGuid(), Name = "Product1" , CreatedDate = DateTime.UtcNow,Price=100, Stock=10 },
                new(){ Id= Guid.NewGuid(), Name = "Product2" , CreatedDate = DateTime.UtcNow,Price=300, Stock=10 },
                new(){ Id= Guid.NewGuid(), Name = "Product3" , CreatedDate = DateTime.UtcNow,Price=200, Stock=10 }
            });
            await _productWriteRepository.SaveChanges();
            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            //8.ders bitti

            var product = _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
