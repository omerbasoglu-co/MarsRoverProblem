using MarsRover;
using MarsRover.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverConsoleApp
{
    public class NinjectBindings : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IPlateau>().To<Plateau>();
            Bind<IRover>().To<Rover>();
        }
    }

}
