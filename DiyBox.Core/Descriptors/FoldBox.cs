namespace DiyBox.Core;

public class FoldBox 
	: Descriptor<object>
{
    protected override void DefineDescription(object data)
    {
        AddLine("Step 5");
		AddLine("Folding box");
		AddLine("Cut out waste marked with X id any");
		AddLine("Cut folds according to drawed lines");
		AddLine("Glue up the box using wall flap at the end");
		AddLine("Glue up the box bottom");
		AddLine("Insert object and glue up box top");
		AddLine("Congratulations ! You can send a package");
    }
}