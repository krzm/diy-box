using DiyBox.Core;
using Moq;

namespace DiyBox.Tests;

public abstract class TapeMarkerTests
{
    protected Mock<IBoxCalc> SetBoxMock(
        BoxMockData d)
    {
        var mock = new Mock<IBoxCalc>();
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

    protected Mock<IWaste> SetWasteMock(
        WasteMockData d)
    {
		var mock = new Mock<IWaste>();
        mock.Setup(c => c.IsFrontWaste).Returns(d.IsFrontWaste);
        mock.Setup(c => c.IsFrontWaste).Returns(d.IsSideWaste);
        mock.Setup(c => c.WasteHeight).Returns(d.WasteHeigth);
        return mock;
    }

    protected Mock<ISheetCalculator> SetSheetCalcMock(
        IBoxCalc box)
    {
		var mock = new Mock<ISheetCalculator>();
        mock.Setup(c => c.Box)
            .Returns(box);
        return mock;
    }

    protected Mock<IBoxCalculator> SetBoxCalcMock(
        ISheetCalculator sheetCalc)
    {
		var mock = new Mock<IBoxCalculator>();
        mock.Setup(c => c.SheetCalculator)
            .Returns(sheetCalc);
        return mock;
    }

    protected Mock<IBoxCalculator> SetBoxCalcMock(
        ISheetCalculator sheetCalc
        , IWaste waste)
    {
		var mock = SetBoxCalcMock(sheetCalc);
        mock.Setup(c => c.Waste)
            .Returns(waste);
        return mock;
    }

    protected Mock<IBoxCalculator> SetBoxCalcMock(
        BoxMockData boxData
    )
    {
        return SetBoxCalcMock(
            SetSheetCalcMock(
                SetBoxMock(boxData).Object
                ).Object);
    }

    protected Mock<IBoxCalculator> SetBoxCalcMock(
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