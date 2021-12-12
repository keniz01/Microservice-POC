using Microservice.Service.Application.Contracts;
using Microservice.Service.Application.Common;
using Microservice.Service.Domain.ValueObjects;

namespace Microservice.Service.Application.UseCases.Search
{
    public class GetSearchTermMatchQueryHandler : IQueryHandler<SearchTermMatchRequest, Result<IReadOnlyList<SearchTermMatch>>>
    {
        private readonly IReadOnlyDatabaseContext _context;

        public GetSearchTermMatchQueryHandler(IReadOnlyDatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<IReadOnlyList<SearchTermMatch>>> Handle(SearchTermMatchRequest request, CancellationToken cancellationToken)
        {
            var sql = $"SELECT * FROM CapitalCity WHERE [Name] LIKE '%' + @searchTerm + '%'";
            var parameters = new { searchTerm = request.SearchTerm.Value };
            var result = await _context.SearchAsync(sql, parameters, cancellationToken);
            return result;
        }
    }
}