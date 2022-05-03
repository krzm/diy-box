namespace DiyBox.Core;

public class PrepareSheet 
	: Descriptor<SheetCompute>
{
    protected override void DefineDescription(
		SheetCompute sheet)
    {
		AddLine("Step 1");
		AddLine("Prepare cardboard sheet");
		AddLine($"of length {sheet?.Size?.X} and heigth {sheet?.Size?.Y}");
    }
}