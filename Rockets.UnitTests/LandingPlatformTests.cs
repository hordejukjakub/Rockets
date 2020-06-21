using Xunit;

namespace Rockets.UnitTests
{
    public class LandingPlatformTests
    {
        [Theory]
        [InlineData(10, 10)]
        [InlineData(10, 15)]
        [InlineData(15, 10)]
        [InlineData(15, 15)]
        public void CoordinateShouldBeOnPlatform(int x, int y)
        {
            var platform = new LandingPlatform(new Coordinate(10, 10), 5, 5);

            var result = platform.IsOnPlatform(new Coordinate(x, y));

            Assert.True(result);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 16)]
        [InlineData(10, 9)]
        [InlineData(9, 15)]
        [InlineData(16, 10)]
        public void CoordinateShouldNotBeOnPlatform(int x, int y)
        {
            var platform = new LandingPlatform(new Coordinate(10, 10), 5, 5);

            var result = platform.IsOnPlatform(new Coordinate(x, y));

            Assert.False(result);
        }
    }
}
