using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway
{
    public abstract class ComponentStartup<TContext> : IComponentStartup where TContext : DbContext
    {
        protected IConfigurationRoot Configuration { get; set; }

        public virtual void Startup(IConfigurationRoot configuration)
        {
            this.Configuration = configuration;
        }

        public virtual void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddEntityFrameworkSqlServer()
            .AddDbContext<TContext>(options =>
            {
                options.UseSqlServer(connectionString);
                
            });

            ConfigureDependencyInjection(services);
        }

        public abstract void ConfigureDependencyInjection(IServiceCollection services);

        public abstract void ConfigureMapping(AutoMapper.IConfiguration action);
    }
}
