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
        RegisterDescriptor<PrintOnSheet>(
			Descriptors.PrintOnSheet);
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
}