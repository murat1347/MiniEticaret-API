using MiniEticaret.Persistence.Contexts;
using MiniEticaret.Persistence.Repositories.InvoiceFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEticaret.Persistence.Repositories.ProductImageFile
{
    public class InvoiceFileReadRepository : ReadRepository<MiniEticaret.Domain.Entities.InvoiceFile>, IInvoiceFileReadRepository
    {
        public InvoiceFileReadRepository(MiniEticaretAPIDBContext context) : base(context)
        {
        }
    }
}
