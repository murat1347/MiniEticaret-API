using MiniEticaret.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEticaret.Persistence.Repositories.File
{
    public class FileWriteRepository : WriteRepository<MiniEticaret.Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(MiniEticaretAPIDBContext context) : base(context)
        {
        }
    }
}
