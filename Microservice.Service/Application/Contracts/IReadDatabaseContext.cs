
using Microservice.Service.Application.Common;
using Microservice.Service.Domain.ValueObjects;

namespace Microservice.Service.Application.Contracts
{
    public interface IReadDatabaseContext
    {
        Task<Result> SearchAsync(string sql, object parameters, CancellationToken cancellationToken);
    }
}