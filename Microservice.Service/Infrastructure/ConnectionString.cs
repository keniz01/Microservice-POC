namespace Microservice.Service.Infrastructure
{
    public class ConnectionString
    {
        public ConnectionString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value;
        }

        public string Value { get; }
    }
}