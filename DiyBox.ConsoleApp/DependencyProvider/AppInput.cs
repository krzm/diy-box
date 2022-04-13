using DIHelper.Unity;
using DiyBox.Core;
using Unity;

namespace DiyBox.ConsoleApp;

public class AppInput 
    : UnityDependencySet
{
    public AppInput(
        IUnityContainer container) 
        : base(container)
    {
    }

    public override void Register()
    {
        Container.RegisterType<IArgsParser<Size3d>, DiyBoxParser>();
    }
}