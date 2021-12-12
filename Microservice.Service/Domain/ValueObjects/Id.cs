using System;

namespace Microservice.Service.Domain.ValueObjects
{
    public sealed class Id
    {
        public Id(Guid value)
        {
            if(value == Guid.Empty)
            {
                throw new IdEmptyException(nameof(value));                
            }

            Value = value;
        }

        public Guid Value { get; }

        public class IdEmptyException : Exception
        {
            public IdEmptyException(string message) : base(message)
            {
                
            }
        }        
    }
}