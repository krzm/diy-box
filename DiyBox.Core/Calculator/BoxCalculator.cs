using System.Collections.Generic;
using System.Linq;

namespace DiyBox.Core;

public class BoxCalculator
    : IBoxCalculator
{
    private readonly ISheetCalculator sheetCalculator;
    private readonly IWaste waste;
    private readonly List<ITapeMarker> tapeMarkers;
    private readonly ITapeMarker horizontalTapeMarker;
    private readonly ITapeMarker verticalFrontTapeMarker;
    private readonly ITapeMarker verticalSideTapeMarker;

    public ISheetCalculator SheetCalculator { get; private set; }
    public IWaste Waste { get; private set; }
    public ITapeMarker HorizontalTapeMarker { get; private set; }
    public ITapeMarker VerticalFrontTapeMarker { get; private set; }
    public ITapeMarker VerticalSideTapeMarker { get; private set; }

    public BoxCalculator(
        ISheetCalculator sheetCalculator
        , IWaste waste
        , List<ITapeMarker> tapeMarkers
    )
    {
        this.sheetCalculator = sheetCalculator;
        this.waste = waste;
        this.tapeMarkers = tapeMarkers;
        horizontalTapeMarker = tapeMarkers
            .FirstOrDefault(m => m is HorizontalTapeMarker);
        verticalFrontTapeMarker = tapeMarkers
            .FirstOrDefault(m => m is VerticalFrontTapeMarker);
        verticalSideTapeMarker = tapeMarkers
            .FirstOrDefault(m => m is VerticalSideTapeMarker);
    }

    public IBoxCalculator Calculate(string[] args)
    {
        SheetCalculator = sheetCalculator.Calculate(args);
        Waste = waste.Calculate(SheetCalculator);
        HorizontalTapeMarker = 
            horizontalTapeMarker.Calculate(
                SheetCalculator.Box);
        VerticalFrontTapeMarker = 
            verticalFrontTapeMarker.Calculate(
                SheetCalculator.Box);
        VerticalSideTapeMarker = 
            verticalSideTapeMarker.Calculate(
                SheetCalculator.Box);
        return this;
    }
}