using MediatR;
using MiniEticaret.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEticaret.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
public CreateProductCommandHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
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
            return new();
        }
    }
}
