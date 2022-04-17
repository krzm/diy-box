using System.Text;

namespace DiyBox.Core;

public class StartCreator 
	: IDescriptor
{
	public string GetDescription(object data)
	{
		var sb = new StringBuilder();
		sb.AppendLine($"Step by Step Box Creator");
		return sb.ToString();
	}
}