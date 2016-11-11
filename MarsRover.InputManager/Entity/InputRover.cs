using MarsRover.Enum;

namespace MarsRover.InputManager.Entity
{
    public class InputRover
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Direction CurrentDirection { get; set; }

        public string Commands { get; set; }
    }
}
