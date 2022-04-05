using System.Collections.Generic;
using CLIFramework;
using DIHelper;
using DiyBox.Core;
using Serilog;
using Unity;
using Unity.Injection;

namespace DiyBox.ConsoleApp;

public class AppProgram<TProgram> 
    : CLIFramework.AppProgram<TProgram>
    where TProgram : IAppProgram
{
    public AppProgram(
        IUnityContainer container) 
        : base(container)
    {
    }

    protected override InjectionConstructor GetInjectionConstructor()
    {
        return new InjectionConstructor(
            new object[]
            {
                Container.Resolve<IArgsParser<Size3d>>()
                , Container.Resolve<IDictionary<Descriptors, IDescriptor>>()
                , Container.Resolve<ILogger>()
            });
    }
}