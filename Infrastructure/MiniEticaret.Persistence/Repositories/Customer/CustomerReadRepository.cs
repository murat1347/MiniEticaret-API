using Microsoft.EntityFrameworkCore;
using MiniEticaret.Application.Repositories;
using MiniEticaret.Domain.Entities;
using MiniEticaret.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniEticaret.Persistence.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(MiniEticaretAPIDBContext context) : base(context)
        {
        }
    }
}
