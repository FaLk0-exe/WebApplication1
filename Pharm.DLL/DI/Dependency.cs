﻿using System.Collections.Immutable;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Pharm.DLL.Interfaces;
using Pharm.DLL.Repositories;
using Pharm.DLL.Services;


namespace Pharm.DLL.DI
{
    public static class Dependency
    {
        
        public static void AddDependencies(this IServiceCollection services)
        {
               
            services.AddSingleton<SqliteConnection>(provider => new SqliteConnection("Data Source=C:\\Users\\aprox\\OneDrive\\Рабочий стол\\s\\db.DAL\\user.db"));
            

            services.AddTransient<IOrderDetailsRepository, OrderDetailsRep>();
            services.AddTransient<IUserOrderRepository, UserOrderRep>();

            services.AddTransient<IUserRepository, UserRep>();

            services.AddTransient<IProductRepository, ProductRep>();
            services.AddTransient<ProductService>();
        }

        
    }
}