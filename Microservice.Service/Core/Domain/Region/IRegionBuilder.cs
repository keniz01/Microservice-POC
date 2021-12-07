using Microservice.Service.Core.Domain.Country;

namespace Microservice.Service.Core.Domain.Region
{
    public interface IRegionBuilder<T> : IWithCoordinates<T>, IWithCountries<T>, IWithArea<T>
    {
        IWithCountries<T> WithCountries(List<Country.Country> countries);        
    }      
}
