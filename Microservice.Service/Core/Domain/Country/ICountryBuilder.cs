using Microservice.Service.Core.Domain.CapitalCity;

namespace Microservice.Service.Core.Domain.Country
{
    public interface ICountryBuilder<T> : IWithCoordinates<T>, IWithCountries<T>, IWithArea<T>, IWithCapitalCities<T>
    {
        IWithCapitalCities<T> WithCapitalCities(List<CapitalCity.CapitalCity> capitalCities);        
    }   
}
