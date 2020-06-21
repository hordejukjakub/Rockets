using Xunit;

namespace Rockets.UnitTests
{
    public class CoordinateTests
    {
        [Theory]
        [InlineData(7, 7)]
        [InlineData(7, 8)]
        [InlineData(7, 6)]
        [InlineData(6, 7)]
        [InlineData(8, 7)]
        public void CoordinatesShouldBeClose(int x, int y)
        {
            var coordinate1 = new Coordinate(7, 7);
            var coordinate2 = new Coordinate(x, y);

            var result = coordinate1.IsCloseTo(coordinate2);
            
            Assert.True(result);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 15)]
        [InlineData(7, 20)]
        [InlineData(20, 7)]
        [InlineData(0, 0)]
        public void CoordinatesShouldNotBeClose(int x, int y)
        {
            var coordinate1 = new Coordinate(7, 7);
            var coordinate2 = new Coordinate(x, y);

            var result = coordinate1.IsCloseTo(coordinate2);

            Assert.False(result);
        }

    }
}
