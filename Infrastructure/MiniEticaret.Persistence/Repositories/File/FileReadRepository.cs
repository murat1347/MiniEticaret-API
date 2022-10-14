using MiniEticaret.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEticaret.Persistence.Repositories.File
{
    public class FileReadRepository : ReadRepository<MiniEticaret.Domain.Entities.File>, IFileReadRepository
    {
        public FileReadRepository(MiniEticaretAPIDBContext context) : base(context)
        {
        }
    }
}
