using DIHelper.Unity;
using Unity;
using Unity.Injection;

namespace DiyBox.Core;

public class DiyBoxWithEvenFoldsSet 
    : UnityDependencySet
{
    public DiyBoxWithEvenFoldsSet(
        IUnityContainer container) 
        : base(container)
    {
    }

    public override void Register()
    {
        Container
            .RegisterSingleton<IArgsParser<Size3d>, Size3dParser>();
        RegisterBoxCalc();
        Container
            .RegisterSingleton<ISheetCompute, SheetCompute>()
            .RegisterSingleton<IBoxToSheetCompute, BoxToSheetCompute>()
            .RegisterSingleton<IWasteCompute, WasteCompute>()

            .RegisterSingleton<ITapeMeasureCompute, HorizontalTapeMeasureCompute>(
                nameof(HorizontalTapeMeasureCompute))
            .RegisterSingleton<ITapeMeasureCompute, VerticalFrontTapeMeasureCompute>(
                nameof(VerticalFrontTapeMeasureCompute))
            .RegisterSingleton<ITapeMeasureCompute, VerticalSideTapeMeasureCompute>(
                nameof(VerticalSideTapeMeasureCompute))

            .RegisterSingleton<IDiyBoxCompute, DiyBoxCompute>(
                new InjectionConstructor(
                    Container.Resolve<IBoxToSheetCompute>()
                    , Container.Resolve<IWasteCompute>()
                    , Container.Resolve<List<ITapeMeasureCompute>>()
                )
            );
    }

    protected virtual void RegisterBoxCalc()
    {
        Container
            .RegisterSingleton<IBoxCompute, BoxWithEvenFoldsCompute>();
    }
}