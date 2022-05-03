using DiyBox.Core;

namespace DiyBox.Tests;

public abstract class BoxComputeTests
{
    protected abstract IBoxCompute GetSut();
    
    protected abstract double GetExpectedFrontFoldHeigth(
        Size3d size);

    protected abstract double GetExpectedSideFoldHeigth(
        Size3d size);
}