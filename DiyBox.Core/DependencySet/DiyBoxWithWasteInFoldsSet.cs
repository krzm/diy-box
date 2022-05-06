using Unity;

namespace DiyBox.Core;

public class DiyBoxWithWasteInFoldsSet
    : DiyBoxWithEvenFoldsSet
{
    public DiyBoxWithWasteInFoldsSet(
        IUnityContainer container) 
        : base(container)
    {
    }

    protected override void RegisterBoxCalc()
    {
        Container
            .RegisterSingleton<IBoxCompute, BoxWithWasteInFoldsCompute>();
    }
}