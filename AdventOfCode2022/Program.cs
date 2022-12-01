using AdventOfCode2022.Architecture;
using AdventOfCode2022.Architecture.Ioc;
using Autofac;

namespace AdventOfCode2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IoC.LetsBegin();
            Start();
        }

        private static void Start()
        {
            using (var scope = IoC.Container.BeginLifetimeScope())
            {
                var appStarter = scope.Resolve<IAppStart>();
                appStarter.Start();
            }
        }
    }
}
