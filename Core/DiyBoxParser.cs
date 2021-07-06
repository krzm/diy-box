using System;
using System.Globalization;
using System.Threading;

namespace Core
{
	public class DiyBoxParser : IArgsParser<Size3d>
	{
		public Size3d Parse(params string[] args)
		{
			if (args.Length != 3)
				throw new ArgumentException(
					"Three args required."
					, nameof(args));
			return new Size3d(
				ParseNumber(args[0], "Length")
				, ParseNumber(args[1], "Height")
				, ParseNumber(args[2], "Depth"));
		}

		private static double ParseNumber(
			string arg
			, string argName)
		{
			var cultureInfo = CultureInfo.CreateSpecificCulture("en");
			Thread.CurrentThread.CurrentCulture = cultureInfo;
			Thread.CurrentThread.CurrentUICulture = cultureInfo;
			if (double.TryParse(arg, NumberStyles.Any, cultureInfo, out double result))
				return result;
			throw new ArgumentException(
				"Wrong format of arg."
				, argName);
		}
	}
}