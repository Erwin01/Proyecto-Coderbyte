using Microsoft.Extensions.DependencyInjection;
using SIGACUtilitarios.Repositories;
using SIGACUtilitarios.Repositories.Implements;
using SIGACUtilitarios.Services;
using SIGACUtilitarios.Services.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGACUtilitarios.Midleware
{
    public static  class IoC
    {
        public static IServiceCollection addDependency(this IServiceCollection services)
        {
     
            //services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
           
            return services;
        }
    }
}
