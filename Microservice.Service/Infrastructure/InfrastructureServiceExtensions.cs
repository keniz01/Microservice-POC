using MediatR;
using Microservice.Service.Application.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Service.Infrastructure
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this ServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMediatR(typeof(InfrastructureServiceExtensions));
            services.AddScoped<IReadOnlyDatabaseContext, ReadOnlyDatabaseContext>();
            services.AddSingleton<ConnectionString>(new ConnectionString(configuration.GetConnectionString("ContinentContext")));
            return services;
        }
    }
}