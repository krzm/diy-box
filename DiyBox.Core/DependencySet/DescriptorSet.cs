using System.Collections.Generic;
using DIHelper.Unity;
using Unity;
using Unity.Injection;

namespace DiyBox.Core;

public class DescriptorSet 
	: UnityDependencySet
{
	public DescriptorSet(
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
		RegisterDescriptor<BoxDimension>(
			Descriptors.BoxDimension);
		RegisterDescriptor<StartCreator>(
			Descriptors.StartCreator);
		RegisterDescriptor<NextStep>(
			Descriptors.NextStep);
		RegisterDescriptor<PrepareSheet>(
			Descriptors.PrepareSheet);
		RegisterDescriptor<MarkSheetHorizontally>(
			Descriptors.MarkSheetHorizontally
			, new InjectionConstructor(
				Container.Resolve<ITapeMarker>(
					nameof(HorizontalTapeMarker))
			));
		RegisterDescriptor<MarkSheetVerticallyFront>(
			Descriptors.MarkSheetVerticallyFront
			, new InjectionConstructor(
				Container.Resolve<ITapeMarker>(
					nameof(VerticalFrontTapeMarker))
			));
		RegisterDescriptor<MarkSheetVerticallySide>(
			Descriptors.MarkSheetVerticallySide
			, new InjectionConstructor(
				Container.Resolve<ITapeMarker>(
					nameof(VerticalSideTapeMarker))
			));
		RegisterDescriptor<FoldBox>(
			Descriptors.FoldBox);
    }

	private void RegisterDescriptor<TDescriptor>(
		Descriptors descriptor)
		where TDescriptor : IDescriptor
	{
		Container.RegisterSingleton<IDescriptor, TDescriptor>(
			descriptor.ToString());
	}
	
	private void RegisterDescriptor<TDescriptor>(
		Descriptors descriptor
		, InjectionConstructor injectionConstructor)
		where TDescriptor : IDescriptor
	{
		Container.RegisterSingleton<IDescriptor, TDescriptor>(
			descriptor.ToString()
			, injectionConstructor);
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