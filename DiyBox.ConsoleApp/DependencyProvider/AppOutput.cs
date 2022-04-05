using System.Collections.Generic;
using DIHelper.Unity;
using DiyBox.Core;
using Unity;

namespace DiyBox.ConsoleApp;

public class AppOutput 
	: UnityDependencySet
{
	public AppOutput(
		IUnityContainer container) 
		: base(container)
	{
	}

	public override void Register()
	{
		RegisterDescriptors();
		RegisterDescriptorDictionary();
	}

    private void RegisterDescriptors()
    {
		RegisterDescriptor<HelpDescriptor>(
			Descriptors.HelpDescriptor);
		RegisterDescriptor<ObjectDimensions>(
			Descriptors.ObjectDimensions);
		RegisterDescriptor<StartCreator>(
			Descriptors.StartCreator);
		RegisterDescriptor<NextStep>(
			Descriptors.NextStep);
		RegisterDescriptor<PrepareSheet>(
			Descriptors.PrepareSheet);
		RegisterDescriptor<MarkSheetHorizontally>(
			Descriptors.MarkSheetHorizontally);
		RegisterDescriptor<MarkSheetVerticallyFront>(
			Descriptors.MarkSheetVerticallyFront);
		RegisterDescriptor<MarkSheetVerticallySide>(
			Descriptors.MarkSheetVerticallySide);
		RegisterDescriptor<FoldBox>(
			Descriptors.FoldBox);
    }

	private void RegisterDescriptor<TDescriptor>(Descriptors descriptor)
		where TDescriptor : IDescriptor
	{
		Container.RegisterType<IDescriptor, TDescriptor>(descriptor.ToString());
	}

    private void RegisterDescriptorDictionary()
	{
		var descriptorDictionary = new Dictionary<Descriptors, IDescriptor>();
		Container.RegisterFactory<IDictionary<Descriptors, IDescriptor>>(
			c => FillDictionary(c, descriptorDictionary));
	}

    private IDictionary<Descriptors, IDescriptor> FillDictionary(
		IUnityContainer c
		, IDictionary<Descriptors, IDescriptor> d)
    {
		Add(c, d, Descriptors.HelpDescriptor);
		Add(c, d, Descriptors.ObjectDimensions);
		Add(c, d, Descriptors.StartCreator);
		Add(c, d, Descriptors.NextStep);
		Add(c, d, Descriptors.PrepareSheet);
		Add(c, d, Descriptors.MarkSheetHorizontally);
		Add(c, d, Descriptors.MarkSheetVerticallyFront);
		Add(c, d, Descriptors.MarkSheetVerticallySide);
		Add(c, d, Descriptors.FoldBox);
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