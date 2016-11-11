using System;
using System.Collections.Generic;
using System.Linq;
using MarsRover.Enum;
using MarsRover.Interface;
using MarsRover.Helper;

namespace MarsRover
{
    public class RoverInvoker 
    {
        private readonly Queue<IRoverCommand> _commandList = new Queue<IRoverCommand>();

        private readonly IRover Rover;
        public RoverInvoker(IRover rover)
        {
            Rover = rover;

            foreach (var ch in rover.CommandParams)
            {
                IRoverCommand command = GetCommand(ch);
                if (command != null)
                {
                    AddCommand(command);
                }
                else
                {
                    throw new NullReferenceException("Girilen karakter için command tanımlı değil.");
                }
            }
        }

        public void Execute()
        {
            while (_commandList.Count > 0)
            {
                _commandList.Dequeue().Execute();
            }
        }

        private void AddCommand(IRoverCommand c)
        {
            _commandList.Enqueue(c);
        }

        private IRoverCommand GetCommand(char commandString)
        {
            IRoverCommand command;

            switch (EnumHelper.Parse<Movement>(commandString))
            {
                case Movement.R:
                    command = new TurnRightCommand(Rover);
                    break;
                case Movement.L:
                    command = new TurnLeftCommand(Rover);
                    break;
                case Movement.M:
                    command = new NextCommand(Rover);
                    break;
                default:
                    command = null;
                    break;
            }

            return command;
        }
    }
}
