#region License Information

// **********************************************************************************************************************************
// Day07Module.cs
// Last Modified: 2022/12/08 11:02 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using System.Linq;
using AdventOfCode2022.Challenges.Day07;
using Autofac;

namespace AdventOfCode2022.Architecture.Ioc.Modules
{
    public class Day07Module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            
            builder.RegisterType<DirectoryManager>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<OutputProcessor>().AsImplementedInterfaces().SingleInstance();
            
            builder.RegisterTypes(typeof(IOutputParser).Assembly
                                                       .GetTypes()
                                                       .Where(t => t.IsClass && 
                                                                   t.IsAbstract == false && 
                                                                   typeof(IOutputParser).IsAssignableFrom(t))
                                                       .ToArray())
                   .SingleInstance()
                   .AsImplementedInterfaces();
            builder.RegisterTypes(typeof(ICommandParser).Assembly
                                                        .GetTypes()
                                                        .Where(t => t.IsClass && 
                                                                    t.IsAbstract == false && 
                                                                    typeof(ICommandParser).IsAssignableFrom(t))
                                                        .ToArray())
                   .SingleInstance()
                   .AsImplementedInterfaces();

        }
    }
}