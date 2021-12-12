namespace Microservice.Service.Domain.ValueObjects
{
    public class SearchTermMatch
    {
        public SearchTermMatch(Id id, Name name, Coordinates coordinates, Area area)
        {
            Id = id;
            Name = name;
            Coordinates = coordinates;
            Area = area;
        }

        public Id Id { get; }
        public Name Name { get; }
        public Coordinates Coordinates { get; }
        public Area Area { get; }
    }
}