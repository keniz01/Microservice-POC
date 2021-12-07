using Xunit;
using System.Collections.Generic;
using Microservice.Service.Core.Domain.CapitalCity;
using Microservice.Service.Core.Domain.Country;
using Microservice.Service.Core.Domain.Region;

namespace Microservice.Service.Core.Domain.Continent.Tests
{
    public class ContinentTests
    {
        private readonly Continent _continent;
        
        public ContinentTests()
        {
            var capitalCity = CapitalCity.CapitalCity.Builder.CreateNew(new Name("Riyadh"))
                .WithCoordinates(new Coordinates(1.092920, 3.129290))
                .WithArea(new Area(19000.90))
                .Build();               
            var country = Country.Country.Builder.CreateNew(new Name("Kingdom of Saudi Arabia"))                
                .WithCapitalCities(new List<CapitalCity.CapitalCity> { capitalCity })
                .WithCoordinates(new Coordinates(1.092920, 3.129290))
                .WithArea(new Area(19000.90))
                .Build();
            var region = Region.Region.Builder.CreateNew(new Name("Middle East Asia"))
                .WithCountries(new List<Country.Country> { country })
                .WithCoordinates(new Coordinates(1.092920, 3.129290))   
                .WithArea(new Area(19000.90))             
                .Build();
            _continent = Continent.Builder.CreateNew(new Name("Asia"))
                .WithRegions(new List<Region.Region> { region })
                .WithCoordinates(new Coordinates(1.092920, 3.129290))   
                .WithArea(new Area(19000.90))              
                .Build();
        }

        [Fact]
        public void ShouldReturnExpectedNameValue()
        {
            var expectedValue = "Asia";
            Assert.Equal(_continent.Name.Value, expectedValue);
        }

        [Fact]
        public void ShouldContainOneOrMoreRegions()
        {
            var expectedValue = 1;
            Assert.Equal(_continent.Regions.Count, expectedValue);
        }
    }
}