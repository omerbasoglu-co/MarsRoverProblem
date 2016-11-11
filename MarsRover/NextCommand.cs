using MarsRover.Interface;

namespace MarsRover
{
    public class NextCommand : IRoverCommand
    {
        readonly IRover _rover;
        public NextCommand(IRover rover)
        {
            _rover = rover;
        }
        public void Execute()
        {
            _rover.Next();
        }
    }
}
