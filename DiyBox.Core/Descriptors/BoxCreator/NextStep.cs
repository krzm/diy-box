using System.Text;

namespace DiyBox.Core;

public class NextStep 
	: IDescriptor
{
	public string GetDescription(object data)
	{
		var sb = new StringBuilder();
		sb.AppendLine($"Push Enter for next step");
		return sb.ToString();
	}
}