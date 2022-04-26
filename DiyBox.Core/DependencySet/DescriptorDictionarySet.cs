using System.Collections.Generic;
using DIHelper.Unity;
using Unity;

namespace DiyBox.Core;

public class DescriptorDictionarySet 
	: UnityDependencySet
{
	public DescriptorDictionarySet(
		IUnityContainer container) 
		: base(container)
	{
	}

	public override void Register()
	{
		Container.RegisterFactory<IDictionary<Descriptors, IDescriptor>>(
			c => FillDictionary(
                c
                , new Dictionary<Descriptors, IDescriptor>()));
	}

    private IDictionary<Descriptors, IDescriptor> FillDictionary(
		IUnityContainer c
		, IDictionary<Descriptors, IDescriptor> d)
    {
		if(d.Count > 0) 
			return d;
		Add(c, d, Descriptors.HelpDescriptor);
		Add(c, d, Descriptors.BoxDimension);
		Add(c, d, Descriptors.StartCreator);
		Add(c, d, Descriptors.NextStep);
		Add(c, d, Descriptors.PrepareSheet);
		Add(c, d, Descriptors.MarkSheetHorizontally);
		Add(c, d, Descriptors.MarkSheetVerticallyFront);
		Add(c, d, Descriptors.MarkSheetVerticallySide);
		Add(c, d, Descriptors.FoldBox);
		Add(c, d, Descriptors.PrintOnSheet);
		return d;
    }

	private void Add(
		IUnityContainer c
		, IDictionary<Descriptors, IDescriptor> d
		, Descriptors de)
	{
		d.Add(
			de
			, ResolveDescriptor(c, de));
	}

    private IDescriptor ResolveDescriptor(
		IUnityContainer c
		, Descriptors descriptor)
	{
		return c.Resolve<IDescriptor>(
			descriptor.ToString());
	}
}