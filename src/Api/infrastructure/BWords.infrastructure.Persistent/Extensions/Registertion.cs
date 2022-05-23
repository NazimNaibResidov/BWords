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
        public  static  IServiceCollection AddInfrastructureRegistertion(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BWords");
            //var connection = configuration.GetConnectionString("b2bslesConnectionString");
            services.AddDbContext<BWordsContext>(options => options.UseSqlServer
            (connectionString)
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking),
            ServiceLifetime.Transient
            );
            //services.AddDbContext<BWordsContext>(options =>
            //{
            //    options.UseSqlServer(connectionString, coig =>
            //    {
            //        coig.EnableRetryOnFailure();
            //    });
            //});
            var seedData = new SeedData();
           //  seedData.SeedAsync(configuration).GetAwaiter().GetResult();
          //  services.AddScoped<BWordsContext>(sp => sp.GetRequiredService<BWordsContext>());
            return services;
           
           
        }
    }
}
