using Microservice.Service.Core.Domain.Country;

namespace Microservice.Service.Core.Domain.Region
{
    public class Region : Entity
    {
        public List<Country.Country> Countries { get; }

        private Region(Guid id, Name name, Coordinates coordinates, List<Country.Country> countries, Area area)
            : base(id, name, coordinates, area) => Countries = countries;

        public class Builder : IRegionBuilder<Region>
        {
            private Guid Id { get; set; }
            private Area Area { get; set; } = new Area(0);
            private Name Name { get; set; }
            private Coordinates Coordinates { get; set; } = new Coordinates(0, 0);
            private List<Country.Country> Countries { get; } = new List<Country.Country>();

            private Builder(Name name) => Name = name;

            public static IRegionBuilder<Region> CreateNew(Name name) => new Builder(name);

            public IWithCountries<Region> WithCountries(List<Country.Country> countries)
            {
                Countries.AddRange(countries);
                return this;
            }

            public IWithCoordinates<Region> WithCoordinates(Coordinates coordinates)
            {
                _ = coordinates ?? throw new ArgumentNullException(nameof(coordinates));
                Coordinates = coordinates;
                return this;
            }

            public IWithArea<Region> WithArea(Area area)
            {
                _ = area ?? throw new ArgumentNullException(nameof(area));
                Area = area;
                return this;
            }

            public Region Build()
            {
                return new Region(Id, Name, Coordinates, Countries, Area);
            }
        }
    }
}
