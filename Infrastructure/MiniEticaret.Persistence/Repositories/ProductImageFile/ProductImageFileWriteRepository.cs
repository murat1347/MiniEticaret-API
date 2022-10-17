using MiniEticaret.Domain.Entities;
using MiniEticaret.Persistence.Contexts;
using MiniEticaret.Persistence.Repositories;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ProductImageFileWriteRepository : WriteRepository<ProductImageFile>, IProductImageFileWriteRepository
    {
        public ProductImageFileWriteRepository(MiniEticaretAPIDBContext context) : base(context)
        {
        }
    }
}