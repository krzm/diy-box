using System.Text;

namespace DiyBox.Core;

public class HelpDescriptor 
	: IDescriptor
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
				a.Contains("Three args required"):
				{
					ProvideMessageForArgsNumberError(sb);
					break;
				};
			case string b when
				b.Contains("Wrong format of arg") ||
				b.Contains("Positive number requaried"):
				{
					ProvideMessageForArgsFromatError(sb);
					break;
				};
		}
	}

	private static void ProvideMessageForArgsNumberError(StringBuilder sb)
	{
		sb.AppendLine("Provide three numbers");
		sb.AppendLine("X, Y - length and heigth of the box front; Z - box depth");
	}

	private static void ProvideMessageForArgsFromatError(StringBuilder sb)
	{
		sb.Append("Provide number grater than zero");
	}
}