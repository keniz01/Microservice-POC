namespace Microservice.Service.Core.Domain.Services
{
    public interface ISearchService
    {
        Task<List<SearchTextMatch>> GetSearchTextMatchesAsync(string searchTest, CancellationToken cancellationToken);
    }
}