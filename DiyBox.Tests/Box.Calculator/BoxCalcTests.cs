using DiyBox.Core;

namespace DiyBox.Tests;

public abstract class BoxCalcTests
{
    protected abstract IBoxCalc GetSut();
    
    protected abstract double GetExpectedFrontFoldHeigth(
        Size3d size);

    protected abstract double GetExpectedSideFoldHeigth(
        Size3d size);
}