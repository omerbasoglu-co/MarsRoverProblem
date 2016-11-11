using MarsRover.Interface;
namespace MarsRover
{
    public class Plateau : IPlateau
    {
        private Point Point { get; set; }

        public void SetPoint(Point point)
        {
            Point = point;
        }

        public Point GetPoint()
        {
            return Point;
        }

        public bool IsValid(Point point)
        {
            var isValidX = point.X >= 0 && point.X <= Point.X;
            var isValidY = point.Y >= 0 && point.Y <= Point.Y;
            return isValidX && isValidY;
        }

    }
}
