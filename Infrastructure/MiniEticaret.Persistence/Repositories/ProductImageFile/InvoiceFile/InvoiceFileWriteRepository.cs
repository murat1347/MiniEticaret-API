using MiniEticaret.Persistence.Contexts;
using MiniEticaret.Persistence.Repositories.InvoiceFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEticaret.Persistence.Repositories.ProductImageFile.InvoiceFile
{
    public class InvoiceFileWriteRepository : WriteRepository<MiniEticaret.Domain.Entities.InvoiceFile>, IInvoiceFileWriteRepository
    {
        public InvoiceFileWriteRepository(MiniEticaretAPIDBContext context) : base(context)
        {
        }
    }
}
