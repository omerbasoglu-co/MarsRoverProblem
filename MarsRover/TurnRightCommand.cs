using MarsRover.Interface;

namespace MarsRover
{
    public class TurnRightCommand : IRoverCommand
    {
        readonly IRover _rover;
        public TurnRightCommand(IRover rover)
        {
           _rover = rover;
        }
        public void Execute()
        {
           _rover.TurnRight();
        }
    }
}
