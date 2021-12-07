using Xunit;
using System;

namespace Microservice.Service.Core.Domain.CapitalCity.Tests
{
    public class NameTests
    {
        [Fact]
        public void MultipleNameClassesShouldBeEqualWhenInstancesWithSameValuesShouldBeEqual()
        {
            var name = new Name("Kenneth");
            var other = new Name("Kenneth");
            Assert.Equal(name, other);
        }
        
        [Fact]
        public void NameShouldThrowArgumentNullExceptionWhenNameArgumentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Name(default!));
        }
    }
}