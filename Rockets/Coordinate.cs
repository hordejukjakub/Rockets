namespace Rockets
{
    public class Coordinate
    {
        public int X { get; }
        public int Y { get; }
        
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool IsCloseTo(Coordinate coordinate) =>
            coordinate.X >= X - 1 && coordinate.X <= X + 1 && coordinate.Y >= Y - 1 && coordinate.Y <= Y + 1;
    }
}