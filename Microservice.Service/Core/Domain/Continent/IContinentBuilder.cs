using Microservice.Service.Core.Domain.Region;

namespace Microservice.Service.Core.Domain.Continent
{
    public interface IContinentBuilder<T> : IWithCoordinates<T>, IWithRegions<T>, IWithArea<T>
    {
        IWithRegions<T> WithRegions(List<Region.Region> regions);        
    }       
}
