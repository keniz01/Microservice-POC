using Xunit;
using System.Threading.Tasks;
using Moq;
using Microservice.Service.Application.Common;
using System.Collections.Generic;
using Microservice.Service.Application.Contracts;
using System;
using Microservice.Service.Application.UseCases.Search;
using System.Threading;

namespace Microservice.Service.Tests.UnitTests
{
    public class SearchUseCaseUnitTests
    {
        [Fact]
        public async Task ShouldVerifySearchAsyncMethodCalledOnce()
        {
            var contextMock = new Mock<IReadDatabaseContext>();
            contextMock.Setup(m => 
                m.SearchAsync(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result<IReadOnlyList<SearchTermMatch>>.Ok(new List<SearchTermMatch>
            {
                new SearchTermMatch(Guid.NewGuid(), "London", -1.928002, 3.176920, 290.90)
            }));

            var handler = new GetSearchTermMatchQueryHandler(contextMock.Object);

            var response = await handler.Handle(new SearchTermMatchRequest(new SearchTerm("blah")), CancellationToken.None);

            contextMock.Verify(m => m.SearchAsync(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}