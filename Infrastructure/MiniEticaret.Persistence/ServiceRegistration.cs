using Microsoft.Extensions.DependencyInjection;
using MiniEticaret.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MiniEticaret.Persistence.Repositories;
using MiniEticaret.Application.Repositories;

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
        }

    }
}
