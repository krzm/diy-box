using System.Text;

namespace Core
{
	public class ObjectDimensions : IDescriptor
	{
		public string GetDescription(object data)
		{
			var size3d = (Size3d)data;
			var sb = new StringBuilder();
			sb.AppendLine();
			sb.AppendLine("Assumption1: is that object is positioned,");
			sb.AppendLine("so that front face contains longest dimension-length,");
			sb.AppendLine("second longest-heigth.");
			sb.AppendLine("Depth is assumed to be shortest dimmension.");
			sb.AppendLine();
			sb.AppendLine($"Object has length {size3d.Length}, height {size3d.Height}, depth {size3d.Depth}.");
			return sb.ToString();
		}
	}
}