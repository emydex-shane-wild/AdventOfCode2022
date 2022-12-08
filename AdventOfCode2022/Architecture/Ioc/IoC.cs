#region License Information

// **********************************************************************************************************************************
// IoC.cs
// Last Modified: 2022/12/01 10:52 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using AdventOfCode2022.Architecture.Ioc.Modules;
using Autofac;

namespace AdventOfCode2022.Architecture.Ioc
{
    public static class IoC
    {
        public static IContainer Container { get; private set; }

        public static void LetsBegin()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new GeneralModule());
            builder.RegisterModule(new Day07Module());
            Container = builder.Build();
        }
    }
}