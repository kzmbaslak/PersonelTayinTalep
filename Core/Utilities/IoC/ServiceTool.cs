using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        // ServiceTool, IoC Container'dan servisleri alabilmemizi sağlar. WebAPI'ye bağlı olmadan servisleri alabilmemizi sağlar.
        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            
            return services;
        }
    }
}
