using Console.Lib;
using Core.Lib;
using DiyBox.Core;
using Unity;

namespace DiyBox.ConsoleApp
{
    public class AppInput : UnityDependencyProvider
    {
        public AppInput(
            IUnityContainer container) 
            : base(container)
        {
        }

        public override void RegisterDependencies()
        {
			Container.RegisterType<IArgsParser<Size3d>, DiyBoxParser>();
        }
    }
}