namespace Microservice.Service.Domain.ValueObjects
{
    public sealed class Area
    {
        public Area(double value)
        {
            if(value < 0)
            {
                throw new AreaLessThanZeroException(nameof(value));
            }
            
            Value = value;
        }

        public double Value { get; }

        public class AreaLessThanZeroException : Exception
        {
            public AreaLessThanZeroException(string message) : base(message)
            {
                
            }
        }        
    }
}