using DIHelper.Unity;
using Unity;

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
        RegisterWizard<SheetWizard>(
            Wizards.SheetWizard);
        RegisterWizard<DiyBoxWizard>(
            Wizards.DiyBoxWizard);
        RegisterWizard<PrintOnSheetWizard>(
            Wizards.PrintOnSheet);
	}

    private void RegisterWizard<TWizard>(
		Wizards wizards)
		where TWizard : IDiyBoxWizard
	{
		Container.RegisterSingleton<IDiyBoxWizard, TWizard>(
			wizards.ToString());
	}
}