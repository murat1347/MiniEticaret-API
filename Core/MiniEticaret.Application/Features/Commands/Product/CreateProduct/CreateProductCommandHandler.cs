using MediatR;
using MiniEticaret.Application.Abstractions.Hubs;
using MiniEticaret.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEticaret.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductHubService _productHubService;
        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductHubService productHubService)
        {
            _productWriteRepository = productWriteRepository;
            _productHubService = productHubService;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var res = await _productWriteRepository.AddAsync(new()
            {
                Name = request.VM_Create_Product.Name,
                Price = (long)request.VM_Create_Product.Price,
                Stock = request.VM_Create_Product.Stock
            });
            await _productWriteRepository.SaveChanges();

            await _productHubService.ProductAddedMessageAsync($"{request.VM_Create_Product.Name} ProductAdded!");
            return new();
        }
    }
}
