#region License Information

// **********************************************************************************************************************************
// GeneralModule.cs
// Last Modified: 2022/12/01 10:52 PM
// Last Modified By: Shane Wild
// Copyright Emydex Technology Ltd @2022
// **********************************************************************************************************************************

#endregion

using AdventOfCode2022.Challenges;
using AdventOfCode2022.Providers;
using Autofac;

namespace AdventOfCode2022.Architecture.Ioc.Modules
{
    public class GeneralModule : Module
    {
        #region Overrides of Module

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ApplicationStart>().AsImplementedInterfaces();
            builder.RegisterType<AdventChallengeProvider>().AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(GeneralModule).Assembly)
                   .Where(t => t.IsAbstract == false &&
                               t.IsClass &&
                               t.IsAssignableTo<AdventChallengeBase>())
                   .AsImplementedInterfaces();
        }

        #endregion
    }
}