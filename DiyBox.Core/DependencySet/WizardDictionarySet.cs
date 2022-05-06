using DIHelper.Unity;
using Unity;

namespace DiyBox.Core;

public class WizardDictionarySet 
	: UnityDependencySet
{
	public WizardDictionarySet(
		IUnityContainer container) 
		: base(container)
	{
	}

	public override void Register()
	{
		Container.RegisterFactory<IDictionary<Wizards, IDiyBoxWizard>>(
			c => FillDictionary(
                c
                , new Dictionary<Wizards, IDiyBoxWizard>()));
	}

    private IDictionary<Wizards, IDiyBoxWizard> FillDictionary(
		IUnityContainer c
		, IDictionary<Wizards, IDiyBoxWizard> d)
    {
		if(d.Count > 0) 
			return d;
		Add(c, d, Wizards.BoxToSheetWizard);
		Add(c, d, Wizards.DiyBoxWizard);
		Add(c, d, Wizards.PrintBoxOnSheet);
		Add(c, d, Wizards.SheetToBoxWizard);
		return d;
    }

	private void Add(
		IUnityContainer c
		, IDictionary<Wizards, IDiyBoxWizard> d
		, Wizards w)
	{
		d.Add(
			w
			, ResolveDescriptor(c, w));
	}

    private IDiyBoxWizard ResolveDescriptor(
		IUnityContainer c
		, Wizards wizards)
	{
		return c.Resolve<IDiyBoxWizard>(
			wizards.ToString());
	}
}