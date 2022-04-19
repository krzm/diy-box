using Unity;

namespace DiyBox.Core;

public class DiyBoxSet 
    : DescriptorSet
{
    public DiyBoxSet(
        IUnityContainer container) 
        : base(container)
    {
    }

    public override void Register()
    {
        base.Register();
        Container
            .RegisterType<IArgsParser<Size3d>, DiyBoxParser>()
            .RegisterType<IBox, Box>()
            .RegisterType<ISheet, Sheet>()
            .RegisterType<ISheetCalculator, SheetCalculator>()
            .RegisterType<IWaste, Waste>()
            .RegisterType<IBoxCalculator, BoxCalculator>()
            .RegisterType<IDiyBoxWizard, SheetWizard>(
                nameof(SheetWizard))
            .RegisterType<IDiyBoxWizard, DiyBoxWizard>(
                nameof(DiyBoxWizard));
    }
}