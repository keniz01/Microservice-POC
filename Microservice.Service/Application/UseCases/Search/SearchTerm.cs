namespace Microservice.Service.Application.UseCases.Search
{
    public class SearchTerm
    {
        public SearchTerm(string value) => Value = value;
        public string Value { get; }
    }
}