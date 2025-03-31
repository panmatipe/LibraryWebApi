using Library.Domain.Repositories;
using Library.Infrastructure.Repositories;
using Library.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            //services.AddDbContext<BooksContext>(optionsBuilder => optionsBuilder.UseSqlServer(config.GetConnectionString("LibraryDb")));
            services.AddDbContext<BooksContext>(optionsBuilder => optionsBuilder.UseSqlite(config.GetConnectionString("LibraryDb")));

            services.AddScoped<IInitialSeeder, InitialSeeder>();
            services.AddScoped<IBooksRepository, BooksRepository>();
        }
    }
}
 