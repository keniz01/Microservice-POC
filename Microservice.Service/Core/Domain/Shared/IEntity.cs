namespace Microservice.Service.Core.Domain
{
    public interface IEntity
    {
        Guid Id { get; }

        Name Name { get; }
        Coordinates Coordinates { get; }
        Area Area { get; }
    }
}
