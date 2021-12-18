namespace Microservice.Service.Application.Common
{
    public class SearchTermMatch
    {
        public SearchTermMatch(Guid id, string name, 
            double latitude, double longitude, double area)
            => (Id, Name, Latitude, Longitude, Area) = (id, name, latitude, longitude, area);
        
        public Guid Id { get; }
        public string Name { get; }
        public double Latitude { get; }
        public double Longitude { get; }
        public double Area { get; }
    }
}