namespace Rockets
{
    public class LandingPlatform
    {
        private readonly Coordinate _startCoordinate;
        private readonly int _sizeX;
        private readonly int _sizeY;

        public LandingPlatform(Coordinate startCoordinate, int sizeX, int sizeY)
        {
            _startCoordinate = startCoordinate;
            _sizeX = sizeX;
            _sizeY = sizeY;
        }

        public bool IsOnPlatform(Coordinate coordinate)
        {
            return coordinate.X >= _startCoordinate.X && coordinate.X <= _startCoordinate.X + _sizeX &&
                   coordinate.Y >= _startCoordinate.Y && coordinate.Y <= _startCoordinate.Y + _sizeY;
        }
    }
}