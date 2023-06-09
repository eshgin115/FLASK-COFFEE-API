﻿using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace FLASK_COFFEE_API.Infrastructure.Configurations
{
    public static class DatabaseConfigurations
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("Eshqin-PC"));
            });
        }
    }
}
