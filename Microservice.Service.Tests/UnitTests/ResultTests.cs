using Xunit;
using Microservice.Service.Domain.ValueObjects;
using Microservice.Service.Application.Common;
using System.Collections.Generic;

namespace Microservice.Service.Tests.UnitTests
{
    public class ResultTests
    {
        [Fact]
        public void ShouldThrowErrorListNorOrEmptyExceptionWhenErrorIsEmptyOrNull()
        {

            Assert.Throws<Result.ErrorListNullOrEmptyException>(() => _ = Result.Fail(null!));
        }
        [Fact]
        public void WhenResultContainsErrorsSucceededShouldEqualFalse()
        {
            var errors = new List<string> { "There is an error somewhere" };
            var result = Result.Fail(errors);
            Assert.True(false == result.Succeeded, $"{result.Succeeded} should be false");
        }

        [Fact]

        public void WhenResultDoesNotContainErrorsSucceededShouldEqualTrue()
        {
            var data = "Hello world";
            var result = Result<string>.Ok(data);
            Assert.True(true == result.Succeeded, $"{result.Succeeded} should be true");
        }

        [Fact]

        public void ShouldThrowDataNullExceptionWhenDataNotInitialised()
        {
            Assert.Throws<Result<string>.DataNullException>(() => _ = Result<string>.Ok(null!));
        }        
    }     
}