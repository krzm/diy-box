namespace DiyBox.Core;

public class PrepareSheet 
	: Descriptor<Sheet>
{
    protected override void DefineDescription(
		Sheet sheet)
    {
		AddLine("Step 1");
		AddLine("Prepare cardboard sheet");
		AddLine($"of length {sheet?.Size?.X} and heigth {sheet?.Size?.Y}");
    }
}