using DiyBox.Core;

namespace DiyBox.Tests.WithEvenFolds;

public abstract class BoxComputeTests
    : Tests.BoxComputeTests
{
    protected override IBoxCompute GetSut()
    {
        return new BoxWithEvenFoldsCompute();
    }

    protected override double GetExpectedFrontFoldHeigth(
        Size3d size) => 
            GetFoldHeigth(size);

    private static double GetFoldHeigth(Size3d size)
    {
        var frontFoldHeigth = size.Z / 2;
        var sideFoldHeigth = size.X / 2;
        var foldHeigth = Math.Min(frontFoldHeigth, sideFoldHeigth);
        return foldHeigth;
    }

    protected override double GetExpectedSideFoldHeigth(
        Size3d size)=> 
            GetFoldHeigth(size);
}