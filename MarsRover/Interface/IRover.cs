using MarsRover.Enum;

namespace MarsRover.Interface
{
    public interface IRover
    {
        IPlateau Plateau { get; set; }
        Direction Direction { get; set; }
        string CommandParams { get; }
        Point Point { get; set; }
        void SetRover(IPlateau plateau, Point point, Direction direction);
        void SetCommandParams(string commandParams);
        void Next();
        void TurnLeft();
        void TurnRight();
    }
}
