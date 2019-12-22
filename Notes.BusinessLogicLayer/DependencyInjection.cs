using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Notes.BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notes.BusinessLogicLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddAutoMapper(assembly);

            var injectableServices = assembly.GetTypes().Where(t => typeof(IInjectableService).IsAssignableFrom(t) && !t.IsAbstract && t.IsClass);
            foreach (var serviceType in injectableServices)
            {
                services.AddScoped(serviceType);
            }

            return services;
        }
    }
}
