using System.Threading;
using Xunit;
using System.Threading.Tasks;
using Microservice.Service.Application.Contracts;
using Microservice.Service.Application.UseCases.Search;

namespace Microservice.Service.Tests.IntegrationTests
{
    public class SearchUseCaseIntegrationTests : TestBase
    {
       [Fact]
        public async Task ShouldVerifySearchResponseSucceeded()
        {
            var context = GetService<IReadOnlyDatabaseContext>();
            var handler = new GetSearchTermMatchQueryHandler(context!);
            var response = await handler.Handle(new SearchTermMatchRequest(new SearchTerm("abc")), CancellationToken.None);
            Assert.True(response.Succeeded);                   
        }        
    }
}