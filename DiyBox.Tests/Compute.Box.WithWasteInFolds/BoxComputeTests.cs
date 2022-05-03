using DiyBox.Core;

namespace DiyBox.Tests.WithWasteInFolds;

public abstract class BoxComputeTests
    : Tests.BoxComputeTests
{
    protected override IBoxCompute GetSut()
    {
        return new BoxWithWasteInFoldsCompute();
    }
    
    protected override double GetExpectedFrontFoldHeigth(
        Size3d size)
    {
        return size.Z / 2;
    }

    protected override double GetExpectedSideFoldHeigth(
        Size3d size)
    {
        return size.X / 2;
    }
}