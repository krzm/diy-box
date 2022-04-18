namespace DiyBox.Core;

public class BoxCalculator
    : IBoxCalculator
{
    private readonly ISheetCalculator sheetCalculator;
    private readonly IWaste waste;

    public ISheetCalculator SheetCalculator { get; private set; }
    public IWaste Waste { get; private set; }

    public BoxCalculator(
        ISheetCalculator sheetCalculator
        , IWaste waste
    )
    {
        this.sheetCalculator = sheetCalculator;
        this.waste = waste;
    }

    public IBoxCalculator Calculate(string[] args)
    {
        SheetCalculator = sheetCalculator.Calculate(args);
        Waste = waste.Calculate(SheetCalculator);
        return this;
    }
}