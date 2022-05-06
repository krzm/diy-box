using Unity;

namespace DiyBox.Core;

public class DiyBoxWithEvenFoldsSet 
    : DiyBoxSet
{
    public DiyBoxWithEvenFoldsSet(
        IUnityContainer container) 
        : base(container)
    {
    }

    protected override void RegisterBoxCalc()
    {
        Container
            .RegisterSingleton<IBoxCompute, BoxWithEvenFoldsCompute>();
    }
}