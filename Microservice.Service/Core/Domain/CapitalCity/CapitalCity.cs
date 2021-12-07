namespace Microservice.Service.Core.Domain.CapitalCity
{
    public partial class CapitalCity : Entity
    {
        private CapitalCity(Guid id, Name name, Coordinates coordinates, Area area) : base(id, name, coordinates, area)
        {

        }

        public class Builder : ICapitalCityBuilder<CapitalCity>
        {
            private Guid Id { get; set; }
            private Area Area { get; set; } = new Area(0);
            private Name Name { get; set; }
            private Coordinates Coordinates { get; set; } = new Coordinates(0, 0);

            private Builder(Name name) => Name = name;

            public static ICapitalCityBuilder<CapitalCity> CreateNew(Name name) => new Builder(name);

            public IWithCoordinates<CapitalCity> WithCoordinates(Coordinates coordinates)
            {
                _ = coordinates ?? throw new ArgumentNullException(nameof(coordinates));
                Coordinates = coordinates;
                return this;
            }

            public IWithArea<CapitalCity> WithArea(Area area)
            {
                _ = area ?? throw new ArgumentNullException(nameof(area));
                Area = area;
                return this;
            }

            public CapitalCity Build()
            {
                return new CapitalCity(Id, Name, Coordinates, Area);
            }
        }
    }
}