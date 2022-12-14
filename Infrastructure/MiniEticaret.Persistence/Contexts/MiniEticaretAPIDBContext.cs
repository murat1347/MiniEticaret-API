
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniEticaret.Domain.Entities;
using MiniEticaret.Domain.Entities.Common;
using MiniEticaret.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEticaret.Persistence.Contexts
{
    public class MiniEticaretAPIDBContext: IdentityDbContext<AppUser,AppRole,string>
    {
        public MiniEticaretAPIDBContext(DbContextOptions options ): base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Domain.Entities.File> Files { get; set; }
        public DbSet<ProductImageFile> ProductImageFiles { get; set; }
        public DbSet<InvoiceFile> InvoiceFiles { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach(var item in datas)
            {
               _= item.State switch
                {
                    EntityState.Added =>item.Entity.CreatedDate =DateTime.UtcNow,
                    EntityState.Modified=> item.Entity.UpdatedDate= DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }

}
