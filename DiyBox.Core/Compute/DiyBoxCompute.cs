namespace DiyBox.Core;

public class DiyBoxCompute
    : IDiyBoxCompute
{
    private readonly IBoxToSheetCompute sheetCalculator;
    private readonly IWasteCompute waste;
    private readonly List<ITapeMeasureCompute> tapeMarkers;
    private readonly ITapeMeasureCompute? horizontalTapeMarker;
    private readonly ITapeMeasureCompute? verticalFrontTapeMarker;
    private readonly ITapeMeasureCompute? verticalSideTapeMarker;

    public IBoxToSheetCompute? SheetCalculator { get; private set; }
    public IWasteCompute? Waste { get; private set; }
    public ITapeMeasureCompute? HorizontalTapeMarker { get; private set; }
    public ITapeMeasureCompute? VerticalFrontTapeMarker { get; private set; }
    public ITapeMeasureCompute? VerticalSideTapeMarker { get; private set; }

    public DiyBoxCompute(
        IBoxToSheetCompute sheetCalculator
        , IWasteCompute waste
        , List<ITapeMeasureCompute> tapeMarkers
    )
    {
        this.sheetCalculator = sheetCalculator;
        this.waste = waste;
        this.tapeMarkers = tapeMarkers;
        horizontalTapeMarker = this.tapeMarkers
            .FirstOrDefault(m => m is HorizontalTapeMeasureCompute);
        verticalFrontTapeMarker = this.tapeMarkers
            .FirstOrDefault(m => m is VerticalFrontTapeMeasureCompute);
        verticalSideTapeMarker = this.tapeMarkers
            .FirstOrDefault(m => m is VerticalSideTapeMeasureCompute);
    }

    public IDiyBoxCompute Compute(string[] args)
    {
        SheetCalculator = sheetCalculator?.Compute(args);
        ArgumentNullException.ThrowIfNull(SheetCalculator);
        Waste = waste?.Compute(SheetCalculator);
        var box = SheetCalculator?.Box;
        ArgumentNullException.ThrowIfNull(box);
        HorizontalTapeMarker = 
            horizontalTapeMarker?.Compute(box);
        VerticalFrontTapeMarker = 
            verticalFrontTapeMarker?.Compute(this);
        VerticalSideTapeMarker = 
            verticalSideTapeMarker?.Compute(this);
        return this;
    }
}