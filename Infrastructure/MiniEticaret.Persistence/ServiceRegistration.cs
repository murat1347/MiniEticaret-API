using Microsoft.Extensions.DependencyInjection;
using MiniEticaret.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MiniEticaret.Persistence.Repositories;
using MiniEticaret.Application.Repositories;
using MiniEticaret.Persistence.Repositories.ProductImageFile.InvoiceFile;
using MiniEticaret.Persistence.Repositories.InvoiceFile;
using MiniEticaret.Persistence.Repositories.ProductImageFile;
using ETicaretAPI.Persistence.Repositories;
using MiniEticaret.Persistence.Repositories.File;

namespace MiniEticaret.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"../../Presentation/MiniEticaret.API"));
            configurationManager.AddJsonFile("appsettings.json");
            services.AddDbContext<MiniEticaretAPIDBContext>(opt => opt.UseNpgsql(configurationManager.GetConnectionString("PosgreSQL")));


            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRepository>();
            services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();
            services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
            services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
        }

    }
}
