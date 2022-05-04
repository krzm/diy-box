using System.Globalization;

namespace DiyBox.Core;

public class Size2dParser 
	: IArgsParser<Size2d>
{
	public Size2d Parse(params string[] args)
	{
		if (args.Length != 2)
			throw new ArgumentException(
				"Two args required"
				, nameof(args));
		return new Size2d(
			ParseNumber(args[0], "Length")
			, ParseNumber(args[1], "Height"));
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
			"Wrong format of arg"
			, argName);
	}
}