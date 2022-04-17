using System.Text;

namespace DiyBox.Core;

public class BoxDimension 
	: IDescriptor
{
	public string GetDescription(object data)
	{
		var size3d = (Size3d)data;
		var sb = new StringBuilder();
		sb.AppendLine($"Define X,Y,Z box coordinate system");
		sb.AppendLine($"Box front is face XY");
		sb.AppendLine($"X is length of the box front");
		sb.AppendLine($"Y is height of the box front");
		sb.AppendLine($"Z is depth of the box");
		sb.AppendLine($"Box has front of length X: {size3d.X} and height Y: {size3d.Y} and box depth is Z: {size3d.Z}");
		return sb.ToString();
	}
}