using System;
using MarsRover.Enum;
using MarsRover.Interface;
using MarsRover.Helper;

namespace MarsRover
{
    public class Rover : IRover
    {
        public IPlateau Plateau { get; set; }

        public Point Point { get; set; }

        public Direction Direction { get; set; }

        public string CommandParams { get; private set; }

        public void SetRover(IPlateau plateau, Point point, Direction direction)
        {
            Plateau = plateau;
            Point = point;

            if (Plateau.IsValid(Point))
            {
                Direction = direction;
                return;
            }

            throw new Exception("Girilen kordinatlar, bulunulan yüzeyden daha büyüktür.");
        }

        public void SetCommandParams(string commandParams)
        {
            CommandParams = commandParams;
        }

        public void Next()
        {
            switch (Direction)
            {
                case Direction.North:
                    Point.Y += 1;
                    break;
                case Direction.East:
                    Point.X += 1;
                    break;
                case Direction.South:
                    Point.Y -= 1;
                    break;
                case Direction.West:
                    Point.X -= 1;
                    break;
                case Direction.None:
                    throw new NullReferenceException("İlerlemek için yön belirtiniz");
            }
        }

        public void TurnRight()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.East;
                    break;
                case Direction.East:
                    Direction = Direction.South;
                    break;
                case Direction.South:
                    Direction = Direction.West;
                    break;
                case Direction.West:
                    Direction = Direction.North;
                    break;
                case Direction.None:
                    throw new NullReferenceException("Dönmek için yön belirtiniz");
            }
        }

        public void TurnLeft()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.West;
                    break;
                case Direction.West:
                    Direction = Direction.South;
                    break;
                case Direction.South:
                    Direction = Direction.East;
                    break;
                case Direction.East:
                    Direction = Direction.North;
                    break;
                case Direction.None:
                    throw new NullReferenceException("Dönmek için yön belirtiniz");
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Point.X, Point.Y, Direction.ToName());
        }
    }
}
