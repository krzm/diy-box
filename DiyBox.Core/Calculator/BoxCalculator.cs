namespace DiyBox.Core;

public class BoxCalculator
    : IBoxCalculator
{
    private readonly ISheetCalculator sheetCalculator;
    private readonly IWaste waste;
    private readonly List<ITapeMarker> tapeMarkers;
    private readonly ITapeMarker? horizontalTapeMarker;
    private readonly ITapeMarker? verticalFrontTapeMarker;
    private readonly ITapeMarker? verticalSideTapeMarker;

    public ISheetCalculator? SheetCalculator { get; private set; }
    public IWaste? Waste { get; private set; }
    public ITapeMarker? HorizontalTapeMarker { get; private set; }
    public ITapeMarker? VerticalFrontTapeMarker { get; private set; }
    public ITapeMarker? VerticalSideTapeMarker { get; private set; }

    public BoxCalculator(
        ISheetCalculator sheetCalculator
        , IWaste waste
        , List<ITapeMarker> tapeMarkers
    )
    {
        this.sheetCalculator = sheetCalculator;
        this.waste = waste;
        this.tapeMarkers = tapeMarkers;
        horizontalTapeMarker = this.tapeMarkers
            .FirstOrDefault(m => m is HorizontalTapeMarker);
        verticalFrontTapeMarker = this.tapeMarkers
            .FirstOrDefault(m => m is VerticalFrontTapeMarker);
        verticalSideTapeMarker = this.tapeMarkers
            .FirstOrDefault(m => m is VerticalSideTapeMarker);
    }

    public IBoxCalculator Calculate(string[] args)
    {
        SheetCalculator = sheetCalculator?.Calculate(args);
        ArgumentNullException.ThrowIfNull(SheetCalculator);
        Waste = waste?.Calculate(SheetCalculator);
        var box = SheetCalculator?.Box;
        ArgumentNullException.ThrowIfNull(box);
        HorizontalTapeMarker = 
            horizontalTapeMarker?.Calculate(box);
        VerticalFrontTapeMarker = 
            verticalFrontTapeMarker?.Calculate(this);
        VerticalSideTapeMarker = 
            verticalSideTapeMarker?.Calculate(this);
        return this;
    }
}