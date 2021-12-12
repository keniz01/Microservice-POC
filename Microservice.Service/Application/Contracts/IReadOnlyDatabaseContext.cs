
using Microservice.Service.Application.Common;
using Microservice.Service.Domain.ValueObjects;

namespace Microservice.Service.Application.Contracts
{
    public interface IReadOnlyDatabaseContext
    {
        Task<Result<IReadOnlyList<SearchTermMatch>>> SearchAsync(string sql, object parameters, CancellationToken cancellationToken);
    }
}