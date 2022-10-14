using MiniEticaret.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEticaret.Persistence.Repositories.ProductImageFile
{
    public class ProductImageFileReadRepository : ReadRepository<MiniEticaret.Domain.Entities.ProductImageFile>, IProductImageFileReadRepository
    {
        public ProductImageFileReadRepository(MiniEticaretAPIDBContext context) : base(context)
        {
        }
    }
}