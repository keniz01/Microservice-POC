namespace Microservice.Service.Core.Domain
{
    public interface IWithCoordinates<T>
    {
        IWithArea<T> WithArea(Area area);
    }
}
