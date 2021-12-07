using Microservice.Service.Core.Domain.Region;

namespace Microservice.Service.Core.Domain.Country
{
    public interface IWithCountries<T>
    {
        IWithCoordinates<T> WithCoordinates(Coordinates coordinates);
    }    
}
