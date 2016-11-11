using System.ComponentModel;
namespace MarsRover.Enum
{
    public enum Direction
    {
        None,

        [Description("N")]
        North,

        [Description("E")]
        East,

        [Description("S")]
        South,

        [Description("W")]
        West
    }
}
