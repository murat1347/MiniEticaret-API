using MiniEticaret.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F = MiniEticaret.Domain.Entities;
namespace MiniEticaret.Persistence.Repositories.File
{
    public interface IFileWriteRepository : IWriteRepository<F::File>
    {
    }
}