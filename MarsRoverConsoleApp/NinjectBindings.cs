using MarsRover;
using MarsRover.Interface;
using Ninject.Modules;

namespace MarsRoverConsoleApp
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IPlateau>().To<Plateau>();
            Bind<IRover>().To<Rover>();
        }
    }

}
