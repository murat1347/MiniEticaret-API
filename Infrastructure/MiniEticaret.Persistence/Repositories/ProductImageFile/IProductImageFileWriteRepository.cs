using MiniEticaret.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEticaret.Persistence.Repositories
{
    public interface IProductImageFileWriteRepository : IWriteRepository<MiniEticaret.Domain.Entities.ProductImageFile>
    {
    }
}
