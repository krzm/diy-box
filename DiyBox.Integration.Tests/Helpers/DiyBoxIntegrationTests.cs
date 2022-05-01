using System.Collections.Generic;
using CLIHelper;
using DiyBox.Core;
using Serilog.Wrapper;

namespace DiyBox.Integration.Tests;

public abstract class DiyBoxIntegrationTests
{
    private IBoxCalc? box;
    private IWaste? waste;
    private ISheet? sheet;
    private IDictionary<Markers, ITapeMarker>? markers;

    protected IBoxCalc? Box => box;
    protected IWaste? Waste => waste;
    protected ISheet? Sheet => sheet;
    protected IDictionary<Markers, ITapeMarker>? TapeMarkers => markers;

    protected IDiyBoxWizard GetDiyBoxWizard(
        LoggerMock logger
        , IInput input)
    {
        box = new BoxCalcWithWasteInFolds();
        sheet = new Sheet();
        waste = new Waste();
        markers = GetTapeMarkers();
        var wizard = new DiyBoxWizard(
            new BoxCalculator(
                new SheetCalculator(
                    new DiyBoxParser()
                    , box
                    , sheet
                )
                , waste
                , new List<ITapeMarker>(markers.Values))
                , GetDescriptorDictionary(markers)
                , input
                , logger
            );
        return wizard;
    }

    private static Dictionary<Markers, ITapeMarker> GetTapeMarkers()
    {
        return new Dictionary<Markers, ITapeMarker>
        {
            { Markers.Horizontal,  new HorizontalTapeMarker() }
            , { Markers.VerticalFront, new VerticalFrontTapeMarker() }
            , { Markers.VerticalSide, new VerticalSideTapeMarker() }
        };
    }

    private IDictionary<Descriptors, IDescriptor> GetDescriptorDictionary(
        IDictionary<Markers, ITapeMarker> markers)
    {
        var d = new Dictionary<Descriptors, IDescriptor>();
        d.Add(
            Descriptors.HelpDescriptor
            , new HelpDescriptor());
        d.Add(
            Descriptors.BoxDimension
            , new BoxDimension());
        d.Add(
            Descriptors.StartCreator
            , new StartCreator());
        d.Add(
            Descriptors.NextStep
            , new NextStep());
        d.Add(
            Descriptors.PrepareSheet
            , new PrepareSheet());
        d.Add(
            Descriptors.MarkSheetHorizontally
            , new MarkSheetHorizontally(
                markers[Markers.Horizontal]));
        d.Add(
            Descriptors.MarkSheetVerticallyFront
            , new MarkSheetVerticallyFront(
                markers[Markers.VerticalFront]));
        d.Add(
            Descriptors.MarkSheetVerticallySide
            , new MarkSheetVerticallySide(
                markers[Markers.VerticalSide]));
        d.Add(
            Descriptors.FoldBox
            , new FoldBox());
        return d;
    }

    protected string[] ArgsToArray(
        double length
        , double heigth
        , double depth)
    {
        return new string[] 
        { 
            length.ToString()
            , heigth.ToString()
            , depth.ToString() 
        };
    }
}