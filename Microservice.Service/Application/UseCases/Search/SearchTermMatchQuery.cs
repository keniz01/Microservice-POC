using MediatR;
using Microservice.Service.Application.Common;
using Microservice.Service.Domain.ValueObjects;

namespace Microservice.Service.Application.UseCases.Search
{
    public class SearchTermMatchRequest : IRequest<Result<IReadOnlyList<SearchTermMatch>>>
    {
        public SearchTermMatchRequest(SearchTerm searchTerm) => SearchTerm = searchTerm; 
        public SearchTerm SearchTerm { get; }
    }
}