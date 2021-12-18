using Dapper;
using Microservice.Service.Application.Contracts;
using Microservice.Service.Application.Common;
using Microsoft.Data.SqlClient;

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

        public async Task<Result> SearchAsync(string sql, object? parameters, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnection(_connectionString.Value);

            try{

                await connection.OpenAsync(cancellationToken);
            }
            catch(SqlException)
            {
                var errors = new List<string> { "" };
                return Result.Fail(errors);
            }

            var rawData = await connection.QueryAsync<dynamic>(sql, parameters);
            var result  = rawData.Select(m => 
                    new SearchTermMatch(m.Id, m.Name, m.Latitude, m.Longitude, m.Area))
                .AsList()
                .AsReadOnly();
                
            return Result<IReadOnlyList<SearchTermMatch>>.Ok(result);
        }
    }
}