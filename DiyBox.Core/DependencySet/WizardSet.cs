using CLIHelper;
using DIHelper.Unity;
using Serilog;
using Unity;
using Unity.Injection;

namespace DiyBox.Core;

public class WizardSet
	: UnityDependencySet
{
	public WizardSet(
		IUnityContainer container) 
		: base(container)
	{
	}

	public override void Register()
	{
        RegisterWizard<DiyBoxWizard>(
            Wizards.DiyBoxWizard);
        RegisterWizard<BoxToSheetWizard>(
            Wizards.BoxToSheetWizard);
        RegisterWizard<PrintBoxOnSheetWizard>(
            Wizards.PrintBoxOnSheet);
        RegisterWizard<SheetToBoxWizard>(
            Wizards.SheetToBoxWizard
            , GetSheetToBoxWizardCtor());
	}

    private void RegisterWizard<TWizard>(
		Wizards wizards)
		where TWizard : IDiyBoxWizard
	{
		Container.RegisterSingleton<IDiyBoxWizard, TWizard>(
			wizards.ToString());
	}

    private void RegisterWizard<TWizard>(
		Wizards wizards
        , InjectionConstructor injectionConstructor)
		where TWizard : IDiyBoxWizard
	{
		Container.RegisterSingleton<IDiyBoxWizard, TWizard>(
			wizards.ToString()
            , injectionConstructor);
	}

    private InjectionConstructor GetSheetToBoxWizardCtor()
    {
        return new InjectionConstructor(
            Container.Resolve<ISheetToBoxCompute>()
            , Container.Resolve<IDiyBoxWizard>(
                Wizards.PrintBoxOnSheet.ToString())
            , Container.Resolve<IDictionary<Descriptors, IDescriptor>>()
            , Container.Resolve<IInput>()
            , Container.Resolve<ILogger>()
        );
    }
}