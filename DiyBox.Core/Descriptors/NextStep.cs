namespace DiyBox.Core;

public class NextStep 
	: Descriptor<object>
{
    protected override void DefineDescription(object data)
    {
        AddLine("Push Enter for next step");
    }
}