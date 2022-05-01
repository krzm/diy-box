using DiyBox.Core;

namespace DiyBox.Tests.WithWasteInFolds;

public abstract class BoxCalcTests
    : Tests.BoxCalcTests
{
    protected override IBoxCalc GetSut()
    {
        return new BoxCalcWithWasteInFolds();
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