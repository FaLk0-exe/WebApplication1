using System.Collections.Immutable;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Sqlite;
using Pharm.DLL.Interfaces;
using Pharm.DLL.Repositories;
using Pharm.DLL.Services;


namespace Pharm.DLL.DI
{
    public static class Dependency
    {
        
        public static void ConfigureServices(this IServiceCollection services)
        {
               
            services.AddSingleton<SqliteConnection>(provider => new SqliteConnection("Data Source=C:/Users/User/source/repos/db.DAL/user.db"));
            

            services.AddTransient<IOrderDetailsRepository, OrderDetailsRep>();
            services.AddTransient<IUserOrderRepository, UserOrderRep>();

            services.AddTransient<IUserRepository, UserRep>();
            services.AddTransient<IStatusRepository,StatusRep>();

            services.AddTransient<IProductRepository, ProductRep>();
            services.AddTransient<ProductService>();
        }

        
    }
}