using BWords.infrastructure.Persistent.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.infrastructure.Persistent.Extensions
{
    public static class Registertion
    {
        public static IServiceCollection AddInfrastructureRegistertion(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BWordsContext>(conf =>
            {
                conf.UseSqlServer(configuration.GetConnectionString("BWords"), coig =>
                {
                    coig.EnableRetryOnFailure();
                });
            });
            //var seedData = new SeedData();
            //seedData.SeedAsync(configuration);
            return services.AddRepstoryRegistertion();
            return services;
        }
    }
}
