using MiniEticaret.Application.Repositories;
using MiniEticaret.Domain.Entities;
using MiniEticaret.Persistence.Contexts;

namespace MiniEticaret.Persistence.Repositories
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(MiniEticaretAPIDBContext context) : base(context)
        {
        }
    }
}
