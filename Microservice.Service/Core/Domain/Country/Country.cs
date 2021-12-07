using Microservice.Service.Core.Domain.CapitalCity;

namespace Microservice.Service.Core.Domain.Country
{
    public partial class Country : Entity
    {
        public List<CapitalCity.CapitalCity> CapitalCities { get; }

        private Country(Guid id, Name name, Coordinates coordinates, List<CapitalCity.CapitalCity> capitalCities, Area area)
            : base(id, name, coordinates, area) => CapitalCities = capitalCities;

        public class Builder : ICountryBuilder<Country>
        {
            private Area Area { get; set; } = new Area(0);
            private Guid Id { get; set; }
            private Name Name { get; set; }
            private Coordinates Coordinates { get; set; } = new Coordinates(0, 0);
            private List<CapitalCity.CapitalCity> CapitalCities { get; } = new List<CapitalCity.CapitalCity>();

            private Builder(Name name) => Name = name;

            public static ICountryBuilder<Country> CreateNew(Name name) => new Builder(name);

            public IWithCapitalCities<Country> WithCapitalCities(List<CapitalCity.CapitalCity> capitalCities)
            {
                CapitalCities.AddRange(capitalCities);
                return this;
            }

            public IWithCoordinates<Country> WithCoordinates(Coordinates coordinates)
            {
                _ = coordinates ?? throw new ArgumentNullException(nameof(coordinates));
                Coordinates = coordinates;
                return this;
            }

            public IWithArea<Country> WithArea(Area area)
            {
                _ = area ?? throw new ArgumentNullException(nameof(area));
                Area = area;
                return this;
            }

            public Country Build()
            {
                return new Country(Id, Name, Coordinates, CapitalCities, Area);
            }
        }
    }
}
