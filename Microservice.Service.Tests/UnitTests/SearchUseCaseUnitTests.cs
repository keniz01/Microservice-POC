using Xunit;
using Microservice.Service.Domain.ValueObjects;
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
        public async Task ShouldVerifyHandlerCallsSearchAsync()
        {
            var contextMock = new Mock<IReadDatabaseContext>();
            contextMock.Setup(m => m.SearchAsync(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Result<IReadOnlyList<SearchTermMatch>>(new List<SearchTermMatch>
            {
                new SearchTermMatch(new Id(Guid.NewGuid()), new Name("London"),
                new Coordinates(-1.928002, 3.176920), new Area(290.90))
            }, true, new List<string>()));

            var handler = new GetSearchTermMatchQueryHandler(contextMock.Object);

            var response = await handler.Handle(new SearchTermMatchRequest(new SearchTerm("blah")), CancellationToken.None);

            contextMock.Verify(m => m.SearchAsync(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}