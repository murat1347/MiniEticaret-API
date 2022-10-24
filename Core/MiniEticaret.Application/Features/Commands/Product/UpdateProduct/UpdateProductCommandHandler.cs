using MediatR;
using Microsoft.Extensions.Logging;
using MiniEticaret.Application.Repositories;

namespace MiniEticaret.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly ILogger<UpdateProductCommandHandler> _logger;
        public UpdateProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, ILogger<UpdateProductCommandHandler> logger)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _logger = logger;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            MiniEticaret.Domain.Entities.Product product = await _productReadRepository.GetByIdAsync(request.Id.ToString());
            product.Stock = request.Stock;
            product.Name = request.Name;
            product.Price = (long)request.Price;
            _logger.LogInformation("Product Updated!");
            await _productWriteRepository.SaveChanges();

            return new();
        }
    }
}
