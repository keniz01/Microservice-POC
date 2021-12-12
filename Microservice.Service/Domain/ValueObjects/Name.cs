namespace Microservice.Service.Domain.ValueObjects
{
    public sealed class Name
    {
        public Name(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new NameNullException(nameof(value));
            }

            Value = value;
        }

        public string Value { get; }

        public class NameNullException : Exception
        {
            public NameNullException(string message) : base(message)
            {
                
            }
        }
    }
}