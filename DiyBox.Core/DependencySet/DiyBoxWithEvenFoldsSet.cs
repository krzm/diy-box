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
            .RegisterSingleton<IArgsParser<Size3d>, DiyBoxParser>();
        RegisterBoxCalc();
        Container
            .RegisterSingleton<ISheet, Sheet>()
            .RegisterSingleton<ISheetCalculator, SheetCalculator>()
            .RegisterSingleton<IWaste, Waste>()

            .RegisterSingleton<ITapeMarker, HorizontalTapeMarker>(
                nameof(HorizontalTapeMarker))
            .RegisterSingleton<ITapeMarker, VerticalFrontTapeMarker>(
                nameof(VerticalFrontTapeMarker))
            .RegisterSingleton<ITapeMarker, VerticalSideTapeMarker>(
                nameof(VerticalSideTapeMarker))

            .RegisterSingleton<IBoxCalculator, BoxCalculator>(
                new InjectionConstructor(
                    Container.Resolve<ISheetCalculator>()
                    , Container.Resolve<IWaste>()
                    , Container.Resolve<List<ITapeMarker>>()
                )
            );
    }

    protected virtual void RegisterBoxCalc()
    {
        Container
            .RegisterSingleton<IBoxCalc, BoxCalcWithEvenFolds>();
    }
}