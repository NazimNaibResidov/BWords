using MediatR;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Api.Application.Extensions
{
    public static class Registertion
    {
        public static   IServiceCollection AddApplicationRegistertion(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();
            services.AddMediatR(assm);
            services.AddAutoMapper(assm);
            services.AddValidatorsFromAssembly(assm);
            return services;
        }
    }
}
