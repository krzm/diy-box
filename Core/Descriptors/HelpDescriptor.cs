using System.Text;

namespace Core
{
	public class HelpDescriptor : IDescriptor
	{
		public string GetDescription(object data)
		{
			var message = (string)data;
			var sb = new StringBuilder();
			sb.AppendLine($"Error: {message}");
			HandleMessagesOnErrors(message, sb);
			return sb.ToString();
		}

		private void HandleMessagesOnErrors(string message, StringBuilder sb)
		{
			switch (message)
			{
				case string a when
					a.Contains("Three args required."):
					{
						ProvideMessageForArgsNumberError(sb);
						break;
					};
				case string b when
					b.Contains("Wrong format of arg.") ||
					b.Contains("Positive number requaried."):
					{
						ProvideMessageForArgsFromatError(sb);
						break;
					};
			}
		}

		private static void ProvideMessageForArgsNumberError(StringBuilder sb)
		{
			sb.AppendLine("Please provide three numbers as arguments.");
			sb.AppendLine("Length, Height, Depth.");
			sb.AppendLine("Assumption is that object is positioned so that front face");
			sb.AppendLine("contains longest dimension length,");
			sb.AppendLine("second longest is heigth.");
			sb.Append("Depth is assumed to be shortest dimmension.");
		}

		private static void ProvideMessageForArgsFromatError(StringBuilder sb)
		{
			sb.Append("Please provide number grater than zero.");
		}
	}
}