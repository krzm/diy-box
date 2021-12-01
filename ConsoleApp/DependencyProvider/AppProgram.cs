using System.Collections.Generic;
using Console.Lib;
using DiyBox.Core;
using Unity;
using Unity.Injection;

namespace DiyBox.ConsoleApp
{
    public class AppProgram<TProgram> : Console.Lib.AppProgram<TProgram>
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
                    , Container.Resolve<IDictionary<string, IDescriptor>>()
                });
        }
    }
}