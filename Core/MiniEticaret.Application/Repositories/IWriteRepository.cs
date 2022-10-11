using Microsoft.EntityFrameworkCore;
using MiniEticaret.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEticaret.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> model);
        Task<bool> RemoveAsync(string id); 
        bool Remove(T model);
        bool RemoveRange(List<T> model);
        bool Update(T model);
        Task<int> SaveChanges();

    }
}
