using Dapper;
using Microservice.Service.Application.Contracts;
using Microservice.Service.Application.Common;
using Microsoft.Data.SqlClient;
using Microservice.Service.Domain.ValueObjects;

namespace Microservice.Service.Infrastructure
{

    public class ReadDatabaseContext : IReadDatabaseContext
    {
        private readonly ConnectionString _connectionString;

        public ReadDatabaseContext(ConnectionString connectionString)
        {
            _ = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            _connectionString = connectionString;
        }

        public async Task<Result<IReadOnlyList<SearchTermMatch>>> SearchAsync(string sql, object? parameters, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnection(_connectionString.Value);

            await connection.OpenAsync(cancellationToken);
            var rawData = await connection.QueryAsync<dynamic>(sql, parameters);
            var result  = rawData.Select(m => 
                    new SearchTermMatch(
                        new Id(m.Id), 
                        new Name(m.Name),
                        new Coordinates(m.Latitude, m.Longitude), 
                        new Area(m.Area)))
                .ToList()
                .AsReadOnly();
            return new Result<IReadOnlyList<SearchTermMatch>>(result, true, new List<string>());
        }
    }
}