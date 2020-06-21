using System.Collections.Generic;
using System.Linq;

namespace Rockets
{
    public class LandingArea
    {
        private readonly LandingPlatform _landingPlatform;
        private readonly List<RocketLandingRequest> _incomingRockets = new List<RocketLandingRequest>();

        public LandingArea(LandingPlatform landingPlatform)
        {
            _landingPlatform = landingPlatform;
        }

        public LandingResponse Land(RocketLandingRequest rocketLandingRequest)
        {
            var previousRequest = _incomingRockets.FirstOrDefault(x => x.RocketId == rocketLandingRequest.RocketId);

            if (previousRequest != null)
            {
                _incomingRockets.Remove(previousRequest);
            }

            if (!_landingPlatform.IsOnPlatform(rocketLandingRequest.Coordinate))
            {
                return LandingResponse.OutOfPlatform;
            }

            if (_incomingRockets.Any(x => x.Coordinate.IsCloseTo(rocketLandingRequest.Coordinate)))
            {
                return LandingResponse.Clash;
            }

            _incomingRockets.Add(rocketLandingRequest);

            return LandingResponse.Ok;
        }
    }
}