using MediatR;
using Microservice.Service.Application.Contracts;
using Microservice.Service.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Service.Application
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this ServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationServiceExtensions));
            return services;
        }
    }
}