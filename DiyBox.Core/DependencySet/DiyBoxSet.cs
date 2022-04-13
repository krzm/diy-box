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
        Container.RegisterType<IArgsParser<Size3d>, DiyBoxParser>();
        Container.RegisterType<IDiyBoxWizard, DiyBoxWizard>();
    }
}