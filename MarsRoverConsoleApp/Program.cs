using System;
using System.Reflection;
using System.Text;
using MarsRover;
using MarsRover.InputManager;
using MarsRover.InputManager.Entity;
using MarsRover.Interface;
using Ninject;

namespace MarsRoverConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputStr = GenerateInput();
            Input input = InputManager.GetInput(inputStr);

            IKernel kernal = new StandardKernel();
            kernal.Load(Assembly.GetExecutingAssembly());
            
            IPlateau plateau = kernal.Get<IPlateau>();
            plateau.SetPoint(new Point(input.X, input.Y));

            foreach (var inputRover in input.InputRovers)
            {
                IRover rover = kernal.Get<Rover>();

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




