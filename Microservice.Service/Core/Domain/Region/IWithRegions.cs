using Microservice.Service.Core.Domain.Continent;

namespace Microservice.Service.Core.Domain.Region
{
    public interface IWithRegions<T>
    {
        IWithCoordinates<T> WithCoordinates(Coordinates coordinates);
    }    
}
