using Console.Lib;
using DiyBox.Core;
using System;
using System.Collections.Generic;

namespace DiyBox.ConsoleApp
{
	public class DiyBoxProgram : IAppProgram
	{
		private readonly IArgsParser<Size3d> parser;
		private readonly IDictionary<string, IDescriptor> descriptors;

		public DiyBoxProgram(
			IArgsParser<Size3d> parser
			, IDictionary<string, IDescriptor> descriptors)
		{
			this.parser = parser;
			this.descriptors = descriptors;
		}
		
		public void Main(string[] args)
		{
			try
			{
				var objectSize = parser.Parse(args);
				var box = new Box(objectSize);
				var sheet = new Sheet(box);
				var waste = new Waste(box, sheet);
				var boxAndWaste = new BoxAndWaste(box, waste);
				System.Console.WriteLine(descriptors[Descriptors.ObjectDimensions].GetDescription(objectSize));
				System.Console.WriteLine(descriptors[Descriptors.StartCreator].GetDescription());
				NextStep();
				System.Console.WriteLine(descriptors[Descriptors.PrepareSheet].GetDescription(sheet));
				NextStep();
				System.Console.WriteLine(descriptors[Descriptors.MarkSheetHorizontally].GetDescription(box));
				NextStep();
				System.Console.WriteLine(descriptors[Descriptors.MarkSheetVerticallyFront].GetDescription(boxAndWaste));
				NextStep();
				System.Console.WriteLine(descriptors[Descriptors.MarkSheetVerticallySide].GetDescription(boxAndWaste));
				NextStep();
				System.Console.WriteLine(descriptors[Descriptors.FoldBox].GetDescription());
			}
			catch (ArgumentException ex)
			{
				System.Console.WriteLine(
					descriptors[Descriptors.Help].GetDescription(ex.Message));
			}
		}

		private void NextStep()
		{
			System.Console.WriteLine(descriptors[Descriptors.NextStep].GetDescription());
			System.Console.ReadLine();
		}
	}
}