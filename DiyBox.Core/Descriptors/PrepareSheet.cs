namespace DiyBox.Core;

public class PrepareSheet 
	: Descriptor<Sheet>
{
    protected override void DefineDescription(
		Sheet sheet)
    {
		Add("Step 1");
		Add("Prepare cardboard sheet");
		Add($"of length {sheet.Size.X} and heigth {sheet.Size.Y}");
    }
}