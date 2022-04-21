using Serilog.Wrapper;
using Xunit;

namespace DiyBox.Integration.Tests;

public class DiyBoxWizardTests
    : DiyBoxIntegrationTests
{
	[Theory]
	[InlineData(new object[] { 15, 10, 20, 5, true, false, 2.5, 75, 25
        , new double[] { 15, 35, 50, 70, 75 }
        , new double[] { 2.5, 7.5, 17.5, 22.5, 25 }
        , new double[] { 7.5, 17.5, 25 }})]
	public void Test_Box(
		double length
		, double heigth
		, double depth
        , double flap
        , bool isFrontWaste
        , bool isSideWaste
        , double wasteHeight
        , double sheetLength
        , double sheetHeigth
        , double[] horizontalMarkers
        , double[] verticalFrontMarkers
        , double[] verticalSideMarkers
        )
    {
        var args = ArgsToArray(length, heigth, depth);
        var sut = GetDiyBoxWizard(new LoggerMock(), new InputMock());

        sut.RunWizard(args);

        Assert.Equal(length, Box?.Front.Wall.X);
        Assert.Equal(heigth, Box?.Front.Wall.Y);
        Assert.Equal(length, Box?.Front.Fold.X);
        Assert.Equal(heigth/2, Box?.Front.Fold.Y);

        Assert.Equal(depth, Box?.Side.Wall.X);
        Assert.Equal(heigth, Box?.Side.Wall.Y);
        Assert.Equal(depth, Box?.Side.Fold.X);
        Assert.Equal(length/2, Box?.Side.Fold.Y);

        Assert.Equal(flap, Box?.WallFlap);

        Assert.Equal(isFrontWaste, Waste?.IsFrontWaste);
        Assert.Equal(isSideWaste, Waste?.IsSideWaste);
        Assert.Equal(wasteHeight, Waste?.WasteHeight);

        Assert.Equal(sheetLength, Sheet?.Size.X);
        Assert.Equal(sheetHeigth, Sheet?.Size.Y);

        Assert.Equal(
            horizontalMarkers[0]
            , TapeMarkers?[Markers.Horizontal].GetMark("Front1"));
        Assert.Equal(
            horizontalMarkers[1]
            , TapeMarkers?[Markers.Horizontal].GetMark("Side1"));
        Assert.Equal(
            horizontalMarkers[2]
            , TapeMarkers?[Markers.Horizontal].GetMark("Front2"));
         Assert.Equal(
            horizontalMarkers[3]
            , TapeMarkers?[Markers.Horizontal].GetMark("Side2"));
        Assert.Equal(
            horizontalMarkers[4]
            , TapeMarkers?[Markers.Horizontal].GetMark("WallFlap"));

        Assert.Equal(
            verticalFrontMarkers[0]
            , TapeMarkers?[Markers.VerticalFront].GetMark("Waste1"));
        Assert.Equal(
            verticalFrontMarkers[1]
            , TapeMarkers?[Markers.VerticalFront].GetMark("Fold1"));
        Assert.Equal(
            verticalFrontMarkers[2]
            , TapeMarkers?[Markers.VerticalFront].GetMark("Wall"));
        Assert.Equal(
            verticalFrontMarkers[3]
            , TapeMarkers?[Markers.VerticalFront].GetMark("Fold2"));
        Assert.Equal(
            verticalFrontMarkers[4]
            , TapeMarkers?[Markers.VerticalFront].GetMark("Waste2"));

         Assert.Equal(
            verticalSideMarkers[0]
            , TapeMarkers?[Markers.VerticalSide].GetMark("Fold1"));
        Assert.Equal(
            verticalSideMarkers[1]
            , TapeMarkers?[Markers.VerticalSide].GetMark("Wall"));
        Assert.Equal(
            verticalSideMarkers[2]
            , TapeMarkers?[Markers.VerticalSide].GetMark("Fold2"));
    }
}