using AutoMapper;
using Common.ApiGateway.Mapping;
using Common.ApiGateway.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway
{
    public class MastersStartup : ComponentStartup<MasterDbContext>
    {
        public override void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<MasterRepository>();
        }

        public override void ConfigureMapping(IConfiguration config)
        {
            config.AddProfile<MasterMappingProfile>();
        }
    }
}
