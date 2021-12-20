using System.Threading;
using Xunit;
using System.Threading.Tasks;
using Microservice.Service.Application.Contracts;
using Microservice.Service.Application.UseCases.Search;
using System;

namespace Microservice.Service.Tests.IntegrationTests
{
    public class ApplicationUseCaseTests : IClassFixture<ApplicationTestBaseFixture>
    {
        private readonly ApplicationTestBaseFixture _fixture;
        public ApplicationUseCaseTests(ApplicationTestBaseFixture fixture) 
            => _fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));

       [Fact]
        public async Task GetSearchTermMatchQueryHandlerShouldReturnSucceededEqualTrue()
        {
            var context = _fixture.GetService<IReadDatabaseContext>();
            var handler = new GetSearchTermMatchQueryHandler(context!);
            var response = await handler.Handle(new SearchTermMatchRequest(new SearchTerm("abc")), CancellationToken.None);
            Assert.True(response.Succeeded);                   
        }        
    }
}