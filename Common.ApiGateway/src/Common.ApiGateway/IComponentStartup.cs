using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway
{
    public interface IComponentStartup
    {
        void Startup(IConfigurationRoot configuration);

        void ConfigureServices(IServiceCollection services, string connectionString);

        void ConfigureDependencyInjection(IServiceCollection services);

        void ConfigureMapping(AutoMapper.IConfiguration action);
    }
}
