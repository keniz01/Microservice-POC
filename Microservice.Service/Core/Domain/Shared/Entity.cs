namespace Microservice.Service.Core.Domain
{
    public abstract class Entity : IEntity
    {
        public Entity(Guid id, Name name, Coordinates coordinates, Area area)
            => (Id, Name, Coordinates, Area) = (id, name,coordinates, area);

        public Guid Id { get; }
        public Name Name { get; }
        public Coordinates Coordinates { get; }
        public Area Area { get; }
    }
}
