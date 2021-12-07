using Microservice.Service.Core.Domain.Country;

namespace Microservice.Service.Core.Domain.CapitalCity
{
    public interface IWithCapitalCities<T>
    {
        IWithCoordinates<T> WithCoordinates(Coordinates coordinates);
    }
}
