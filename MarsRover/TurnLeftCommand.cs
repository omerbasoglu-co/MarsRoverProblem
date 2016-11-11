using MarsRover.Interface;

namespace MarsRover
{
    public class TurnLeftCommand : IRoverCommand
    {
        readonly IRover _rover;
        public TurnLeftCommand(IRover rover)
        {
            _rover = rover;
        }

        public void Execute()
        {
            _rover.TurnLeft();
        }
    }
}
