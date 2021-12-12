using Xunit;
using Microservice.Service.Domain.ValueObjects;

namespace Microservice.Service.Tests.UnitTests
{
    public class AreaTests
    {
        [Fact]
        public void ShouldErrorWhenInitialisedWithValueLessThanZero()
        {
            Assert.Throws<Area.AreaLessThanZeroException>(() => _ = new Area(-1));
        }

        [Fact]
        public void ShouldReturnSameValueWhenInitialisedWithValidValue()
        {
            var expectedValue = 290.95;
            var name = new Area(expectedValue);
            Assert.True(expectedValue == name.Value);
        }
    }    
}