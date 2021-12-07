namespace Microservice.Service.Core.Domain
{
    public class SearchTextMatch
    {
        public SearchTextMatch(IReadOnlyList<Country.Country> matches) => Matches = matches;
        public IReadOnlyList<Country.Country> Matches { get; }
    }   
}
