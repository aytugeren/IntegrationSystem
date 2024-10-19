using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Interfaces;
using Product.Data.ContextFolder;
using Product.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data
{
    public static class ProductDataServiceRegistiration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configration)
        {
            services.AddDbContext<ProductContext>(options =>
            options.UseNpgsql(configration.GetConnectionString("DatabaseConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
