using Xunit;
using Microservice.Service.Domain.ValueObjects;

namespace Microservice.Service.Tests.UnitTests
{
    public class NameTests
    {
        [Fact]
        public void ShouldErrorWhenInitialisedWithNullOrEmptyValue()
        {
            Assert.Throws<Name.NameNullException>(() => _ = new Name(""));
        }

        [Fact]
        public void ShouldReturnSameValueWhenInitialisedWithValidValue()
        {
            var expectedValue = "London";
            var name = new Name(expectedValue);
            Assert.True(expectedValue == name.Value);
        }
    }
}