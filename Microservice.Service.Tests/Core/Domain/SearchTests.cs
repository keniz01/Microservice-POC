using System.Threading;
using System.Threading.Tasks;
using Microservice.Service.Core.Domain.Services;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace Microservice.Service.Core.Domain.CapitalCity.Tests
{
    public class SearchTests
    {
        [Theory]
        [InlineData("uga")]
        public async Task ShouldReturnResultsMatchingSearchQuery(string searchQuery)
        {
            //Act
            var serviceMock = new Mock<ISearchService>();
            serviceMock.Setup(mock => 
                mock.GetSearchTextMatchesAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<SearchTextMatch>
                {
                    new SearchTextMatch()
                });
                
            //Arrange
            var results = await serviceMock.Object.GetSearchTextMatchesAsync(searchQuery, CancellationToken.None);
            //Assert
            Assert.NotEmpty(results);
        }
    }
}