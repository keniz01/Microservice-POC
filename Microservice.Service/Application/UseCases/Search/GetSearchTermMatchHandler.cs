using Microservice.Service.Application.Contracts;
using Microservice.Service.Application.Common;
using Microservice.Service.Domain.ValueObjects;
using System.Text;

namespace Microservice.Service.Application.UseCases.Search
{
    public class GetSearchTermMatchQueryHandler : IQueryHandler<SearchTermMatchRequest, Result>
    {
        private readonly IReadDatabaseContext _context;

        public GetSearchTermMatchQueryHandler(IReadDatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result> Handle(SearchTermMatchRequest request, CancellationToken cancellationToken)
        {
            var sql = new StringBuilder()
                .AppendLine("SELECT Id, Name, Latitude, Longitude, Area FROM CapitalCity WHERE [Name] LIKE '%' + @searchTerm + '%'")
                .AppendLine("ORDER BY Name;")
                .ToString();

            var parameters = new { searchTerm = request.SearchTerm.Value };
            var result = await _context.SearchAsync(sql, parameters, cancellationToken);
            return result;
        }
    }
}