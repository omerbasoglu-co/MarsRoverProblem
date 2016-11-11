using MarsRover;
using MarsRover.Enum;
using MarsRover.InputManager;
using MarsRover.InputManager.Entity;
using MarsRover.Interface;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsRoverConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputStr = GenerateInput();
            Input input = InputManager.GetInput(inputStr);

            IKernel _Kernal = new StandardKernel();
            _Kernal.Load(Assembly.GetExecutingAssembly());
            
            IPlateau plateau = _Kernal.Get<IPlateau>();
            plateau.SetPoint(new Point(input.X, input.Y));

            foreach (var inputRover in input.InputRovers)
            {
                IRover rover = _Kernal.Get<Rover>();

                rover.SetRover(plateau, new Point(inputRover.X,inputRover.Y),inputRover.CurrentDirection);
                rover.SetCommandParams(inputRover.Commands);

                RoverInvoker roverInvorker = new RoverInvoker(rover);
                roverInvorker.Execute();

                //Output
                Console.WriteLine(rover.ToString());
            }

            Console.ReadKey();
        }

        static string GenerateInput()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("5 5");
            sb.AppendLine("1 2 N");
            sb.AppendLine("LMLMLMLMM");
            sb.AppendLine("3 3 E");
            sb.AppendLine("MMRMMRMRRM");

            /* Passed
            sb.AppendLine("5 5");
            sb.AppendLine("1 2     N");
            sb.AppendLine("LML     MLMLMM");
            sb.AppendLine("3    3 E");
            sb.AppendLine("    MMRMMRMRRM");
            */

            /* Error
            sb.AppendLine("5 5 5");
            sb.AppendLine("LML     MLMLMM");
            sb.AppendLine("3    3 E");
            sb.AppendLine("    MMRMMRMRRM");
            */

            //sb.AppendLine("123");

            return sb.ToString();
        }
    }
}




