using CLIHelper;
using DiyBox.Core;
using Serilog.Wrapper;

namespace DiyBox.Integration.Tests;

public abstract class DiyBoxIntegrationTests
{
    private IBoxCompute? box;
    private IWasteCompute? waste;
    private ISheetCompute? sheet;
    private IDictionary<Markers, ITapeMeasureCompute>? markers;

    protected IBoxCompute? Box => box;
    protected IWasteCompute? Waste => waste;
    protected ISheetCompute? Sheet => sheet;
    protected IDictionary<Markers, ITapeMeasureCompute>? TapeMarkers => markers;

    protected IDiyBoxWizard GetDiyBoxWizard(
        LoggerMock logger
        , IInput input)
    {
        box = new BoxWithWasteInFoldsCompute();
        sheet = new SheetCompute();
        waste = new WasteCompute();
        markers = GetTapeMarkers();
        var wizard = new DiyBoxWizard(
            new DiyBoxCompute(
                new BoxToSheetCompute(
                    new DiyBoxParser()
                    , box
                    , sheet
                )
                , waste
                , new List<ITapeMeasureCompute>(markers.Values))
                , GetDescriptorDictionary(markers)
                , input
                , logger
            );
        return wizard;
    }

    private static Dictionary<Markers, ITapeMeasureCompute> GetTapeMarkers()
    {
        return new Dictionary<Markers, ITapeMeasureCompute>
        {
            { Markers.Horizontal,  new HorizontalTapeMeasureCompute() }
            , { Markers.VerticalFront, new VerticalFrontTapeMeasureCompute() }
            , { Markers.VerticalSide, new VerticalSideTapeMeasureCompute() }
        };
    }

    private IDictionary<Descriptors, IDescriptor> GetDescriptorDictionary(
        IDictionary<Markers, ITapeMeasureCompute> markers)
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