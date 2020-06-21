using System.Linq;
using Xunit;

namespace Rockets.UnitTests
{
    public class LandingAreaTests
    {
        private LandingArea CreateLandingArea() =>
            new LandingArea(new LandingPlatform(new Coordinate(5, 5), 10, 10));

        [Fact]
        public void ShouldReturnOkForRocketInPlatformStartPosition()
        {
            var landingArea = CreateLandingArea();
            var rocketRequest = new RocketLandingRequest(1, new Coordinate(5, 5));

            var result = landingArea.Land(rocketRequest);

            Assert.Equal(LandingResponse.Ok, result);
        }

        [Fact]
        public void ShouldReturnOutOfPlatformForRocketOutsideOfPlatform()
        {
            var landingArea = CreateLandingArea();
            var rocketRequest = new RocketLandingRequest(1, new Coordinate(16, 15));

            var result = landingArea.Land(rocketRequest);

            Assert.Equal(LandingResponse.OutOfPlatform, result);
        }

        [Theory]
        [InlineData(7, 7)]
        [InlineData(7, 8)]
        [InlineData(7, 6)]
        [InlineData(6, 7)]
        [InlineData(8, 7)]
        public void ShouldReturnClashForPreviousRocketPositionAndNearby(int x, int y)
        {
            var landingArea = CreateLandingArea();
            var firstRocket = new RocketLandingRequest(1, new Coordinate(7, 7));
            var secondRocket = new RocketLandingRequest(2, new Coordinate(x, y));

            landingArea.Land(firstRocket);
            var result = landingArea.Land(secondRocket);

            Assert.Equal(LandingResponse.Clash, result);
        }

        [Fact]
        public void ShouldReturnOkForRocketsWithDistanceOf2Coordinates()
        {
            var landingArea = CreateLandingArea();
            var rocketRequests = new[]
            {
                new RocketLandingRequest(1, new Coordinate(5, 5)),
                new RocketLandingRequest(2, new Coordinate(7, 5)),
                new RocketLandingRequest(3, new Coordinate(9, 5)),
                new RocketLandingRequest(4, new Coordinate(5, 7)),
                new RocketLandingRequest(5, new Coordinate(5, 9)),
                new RocketLandingRequest(6, new Coordinate(10, 10))
            };

            var results = rocketRequests.Select(landingArea.Land);

            Assert.All(results, result => Assert.Equal(LandingResponse.Ok, result));
        }

        [Fact]
        public void ShouldReturnOkForRocketOnCoordinateThatPreviousRocketLeft()
        {
            var landingArea = CreateLandingArea();
            var rocketRequests = new []
            {
                new RocketLandingRequest(1, new Coordinate(5, 5)),
                new RocketLandingRequest(1, new Coordinate(8, 8)),
                new RocketLandingRequest(2, new Coordinate(5, 5))
            };

            var results = rocketRequests.Select(landingArea.Land);

            Assert.All(results, result => Assert.Equal(LandingResponse.Ok, result));
        }
    }
}
