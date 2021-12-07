namespace Microservice.Service.Core.Domain.CapitalCity
{
    public interface ICapitalCityBuilder<T> : IWithCoordinates<T>, IWithArea<T>
    {
        IWithCoordinates<T> WithCoordinates(Coordinates coordinates);
    }
}
