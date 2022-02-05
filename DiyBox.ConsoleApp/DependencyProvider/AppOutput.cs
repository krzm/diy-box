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
		RegisterDescriptorDictionary();
	}

	private void RegisterDescriptorDictionary()
	{
		Container.RegisterType<IDescriptor, HelpDescriptor>(Descriptors.Help);
		Container.RegisterType<IDescriptor, ObjectDimensions>(Descriptors.ObjectDimensions);
		Container.RegisterType<IDescriptor, StartCreator>(Descriptors.StartCreator);
		Container.RegisterType<IDescriptor, NextStep>(Descriptors.NextStep);
		Container.RegisterType<IDescriptor, PrepareSheet>(Descriptors.PrepareSheet);
		Container.RegisterType<IDescriptor, MarkSheetHorizontally>(Descriptors.MarkSheetHorizontally);
		Container.RegisterType<IDescriptor, MarkSheetVerticallyFront>(Descriptors.MarkSheetVerticallyFront);
		Container.RegisterType<IDescriptor, MarkSheetVerticallySide>(Descriptors.MarkSheetVerticallySide);
		Container.RegisterType<IDescriptor, FoldBox>(Descriptors.FoldBox);

		Container.RegisterFactory<IDictionary<string, IDescriptor>>(
			m => new Dictionary<string, IDescriptor>
			{
				{ Descriptors.Help, m.Resolve<IDescriptor>( Descriptors.Help) }
				, { Descriptors.ObjectDimensions, m.Resolve<IDescriptor>( Descriptors.ObjectDimensions) }
				, { Descriptors.StartCreator, m.Resolve<IDescriptor>( Descriptors.StartCreator) }
				, { Descriptors.NextStep, m.Resolve<IDescriptor>( Descriptors.NextStep) }
				, { Descriptors.PrepareSheet, m.Resolve<IDescriptor>( Descriptors.PrepareSheet) }
				, { Descriptors.MarkSheetHorizontally, m.Resolve<IDescriptor>( Descriptors.MarkSheetHorizontally) }
				, { Descriptors.MarkSheetVerticallyFront, m.Resolve<IDescriptor>( Descriptors.MarkSheetVerticallyFront) }
				, { Descriptors.MarkSheetVerticallySide, m.Resolve<IDescriptor>( Descriptors.MarkSheetVerticallySide) }
				, { Descriptors.FoldBox, m.Resolve<IDescriptor>( Descriptors.FoldBox) }
			});
	}
}