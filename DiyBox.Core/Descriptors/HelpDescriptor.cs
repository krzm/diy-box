namespace DiyBox.Core;

public class HelpDescriptor 
	: Descriptor<string>
{
	protected override void DefineDescription(
		string message)
    {
		AddLine($"Error: {message}");
		HandleMessagesOnErrors(message);
    }

	private void HandleMessagesOnErrors(
		string message)
	{
		switch (message)
		{
			case string a when
				a.Contains("Three args required"):
				{
					ProvideMessageForArgsNumberError();
					break;
				};
			case string b when
				b.Contains("Wrong format of arg") ||
				b.Contains("Positive number requaried"):
				{
					ProvideMessageForArgsFromatError();
					break;
				};
		}
	}

	private void ProvideMessageForArgsNumberError()
	{
		AddLine("Provide three numbers");
		AddLine("X, Y - length and heigth of the box front; Z - box depth");
	}

	private void ProvideMessageForArgsFromatError()
	{
		AddLine("Provide number grater than zero");
	}
}