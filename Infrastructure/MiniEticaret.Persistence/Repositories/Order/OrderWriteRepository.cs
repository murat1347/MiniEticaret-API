using MiniEticaret.Application.Repositories;
using MiniEticaret.Domain.Entities;
using MiniEticaret.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEticaret.Persistence.Repositories
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(MiniEticaretAPIDBContext context) : base(context)
        {
        }
    }
}
