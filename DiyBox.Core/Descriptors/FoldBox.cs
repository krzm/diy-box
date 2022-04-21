namespace DiyBox.Core;

public class FoldBox 
	: Descriptor<object>
{
    protected override void DefineDescription(object data)
    {
        Add("Step 5");
		Add("Folding box");
		Add("Cut out waste marked with X id any");
		Add("Cut folds according to drawed lines");
		Add("Glue up the box using wall flap at the end");
		Add("Glue up the box bottom");
		Add("Insert object and glue up box top");
		Add("Congratulations ! You can send a package");
    }
}