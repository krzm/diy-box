using DiyBox.Core;
using Moq;

namespace DiyBox.Tests;

public abstract class ComputeTests
{
    protected Mock<IBoxCompute> SetBoxMock(
        BoxMockData d)
    {
        var mock = new Mock<IBoxCompute>();
        var frontWall = new Size2d(d.Length, d.Heigth);
        var frontFold = new Size2d(d.Length, d.Heigth/2);
        var front = new BoxWall(frontWall, frontFold);
        mock.Setup(b => b.Front).Returns(front);
        var sideWall = new Size2d(d.Depth, d.Heigth);
        var sideFold = new Size2d(d.Depth, d.Length/2);
        var side = new BoxWall(sideWall, sideFold);
        mock.Setup(b => b.Side).Returns(side);
        mock.Setup(b => b.WallFlap).Returns(d.Flap);
        return mock;
    }

    protected Mock<IWasteCompute> SetWasteMock(
        WasteMockData d)
    {
		var mock = new Mock<IWasteCompute>();
        mock.Setup(c => c.IsFrontWaste).Returns(d.IsFrontWaste);
        mock.Setup(c => c.IsFrontWaste).Returns(d.IsSideWaste);
        mock.Setup(c => c.WasteHeight).Returns(d.WasteHeigth);
        return mock;
    }

    protected Mock<IBoxToSheetCompute> SetSheetCalcMock(
        IBoxCompute box)
    {
		var mock = new Mock<IBoxToSheetCompute>();
        mock.Setup(c => c.Box)
            .Returns(box);
        return mock;
    }

    protected Mock<IDiyBoxCompute> SetBoxCalcMock(
        IBoxToSheetCompute sheetCalc)
    {
		var mock = new Mock<IDiyBoxCompute>();
        mock.Setup(c => c.SheetCalculator)
            .Returns(sheetCalc);
        return mock;
    }

    protected Mock<IDiyBoxCompute> SetBoxCalcMock(
        IBoxToSheetCompute sheetCalc
        , IWasteCompute waste)
    {
		var mock = SetBoxCalcMock(sheetCalc);
        mock.Setup(c => c.Waste)
            .Returns(waste);
        return mock;
    }

    protected Mock<IDiyBoxCompute> SetBoxCalcMock(
        BoxMockData boxData
    )
    {
        return SetBoxCalcMock(
            SetSheetCalcMock(
                SetBoxMock(boxData).Object
                ).Object);
    }

    protected Mock<IDiyBoxCompute> SetBoxCalcMock(
        BoxMockData boxData
        , WasteMockData wasteData
    )
    {
        return SetBoxCalcMock(
            SetSheetCalcMock(
                SetBoxMock(boxData).Object
                ).Object
            , SetWasteMock(wasteData)
                .Object
        );
    }
}