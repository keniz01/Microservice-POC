namespace Microservice.Service.Core.Domain
{
    public class Coordinates
    {
        public Coordinates(double latitude, double longitude) 
            => (Latitude, Longitude) = (latitude, longitude);

        public double Latitude { get; }
        public double Longitude { get; }
    }  
}
