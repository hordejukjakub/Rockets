namespace Rockets
{
    public class RocketLandingRequest
    {
        public int RocketId { get; }
        public Coordinate Coordinate { get; }

        public RocketLandingRequest(int rocketId, Coordinate coordinate)
        {
            RocketId = rocketId;
            Coordinate = coordinate;
        }
    }
}