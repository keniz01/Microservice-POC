using Microservice.Service.Core.Domain.Region;

namespace Microservice.Service.Core.Domain.Continent
{
    public partial class Continent : Entity
    {
        private Continent(Guid id, Name name, Coordinates coordinates, IList<Region.Region> regions, Area area)
         : base(id, name, coordinates, area) => Regions = regions;

        public IList<Region.Region> Regions { get; private set; }

        public class Builder : IContinentBuilder<Continent>
        {
            private Guid Id { get; set; }
            private Area Area { get; set; } = new Area(0);
            private Name Name { get; set; }
            private Coordinates Coordinates { get; set; } = new Coordinates(0, 0);
            private List<Region.Region> Regions { get; } = new List<Region.Region>();

            private Builder(Name name) => Name = name;

            public static IContinentBuilder<Continent> CreateNew(Name name) => new Builder(name);

            public IWithRegions<Continent> WithRegions(List<Region.Region> regions)
            {
                Regions.AddRange(regions);
                return this;
            }

            public IWithCoordinates<Continent> WithCoordinates(Coordinates coordinates)
            {
                _ = coordinates ?? throw new ArgumentNullException(nameof(coordinates));
                Coordinates = coordinates;
                return this;
            }

            public IWithArea<Continent> WithArea(Area area)
            {
                _ = area ?? throw new ArgumentNullException(nameof(area));
                Area = area;
                return this;
            }

            public Continent Build()
            {
                return new Continent(Id, Name, Coordinates, Regions, Area);
            }
        }
    }
}
