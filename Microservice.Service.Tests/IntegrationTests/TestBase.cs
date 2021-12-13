using System;
using Microservice.Service.Application;
using Microservice.Service.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Service.Tests.IntegrationTests
{
    public class TestBaseFixture
    {
        private readonly ServiceProvider _serviceProvider;
        public TestBaseFixture()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", false, true)
                .Build();


            var services = new ServiceCollection();
            services.AddApplicationServices();
            services.AddInfrastructureServices(configuration);

            _serviceProvider = services.BuildServiceProvider();
        }

        public T? GetService<T>() where T : notnull
        {
            using var scope = _serviceProvider.CreateScope();
            return scope.ServiceProvider.GetRequiredService<T>();
        }
    }
}