using PluginIntegrationMVC.Application.Interfaces;
using PluginIntegrationMVC.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace PluginIntegrationMVC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IDecodingService, DecodingService>();

            return services;
        }
    }
}
