namespace DiyBox.Core;

public class BoxCalculator
    : IBoxCalculator
{
    private readonly ISheetCalculator sheetCalculator;
    private readonly IWaste waste;
    private readonly ITapeMarker horizontalTapeMarker;

    public ISheetCalculator SheetCalculator { get; private set; }
    public IWaste Waste { get; private set; }
    public ITapeMarker HorizontalTapeMarker { get; private set; }

    public BoxCalculator(
        ISheetCalculator sheetCalculator
        , IWaste waste
        , ITapeMarker horizontalTapeMarker
    )
    {
        this.sheetCalculator = sheetCalculator;
        this.waste = waste;
        this.horizontalTapeMarker = horizontalTapeMarker;
    }

    public IBoxCalculator Calculate(string[] args)
    {
        SheetCalculator = sheetCalculator.Calculate(args);
        Waste = waste.Calculate(SheetCalculator);
        HorizontalTapeMarker = horizontalTapeMarker.Calculate(SheetCalculator.Box);
        return this;
    }
}