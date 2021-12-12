using Xunit;
using Microservice.Service.Domain.ValueObjects;
using System;

namespace Microservice.Service.Tests.UnitTests
{
    public class IdTests
    {
        [Fact]
        public void ShouldErrorWhenInitialisedWithEmptyValue()
        {
            Assert.Throws<Id.IdEmptyException>(() => _ = new Id(Guid.Empty));
        }

        [Fact]
        public void ShouldReturnSameValueWhenInitialisedWithValidValue()
        {
            var expectedValue = Guid.NewGuid();
            var id = new Id(expectedValue);
            Assert.True(expectedValue == id.Value);
        }
    }    
}