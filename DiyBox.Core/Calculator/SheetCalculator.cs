namespace DiyBox.Core;

public class SheetCalculator 
    : ISheetCalculator
{
    private readonly IArgsParser<Size3d> parser;
    private readonly IBoxCalc box;
    private readonly ISheet sheet;

    public Size3d? BoxSize { get; private set; }
    public IBoxCalc? Box { get; private set; }
    public ISheet? Sheet { get; private set; }

    public SheetCalculator(
        IArgsParser<Size3d> parser
        , IBoxCalc box
        , ISheet sheet
    )
    {
        this.parser = parser;
        this.box = box;
        this.sheet = sheet;
    }

    public ISheetCalculator Calculate(string[] args)
    {
        BoxSize = parser.Parse(args);
        Box = box.Calculate(BoxSize);
        Sheet = sheet.Calculate(Box);
        return this;
    }
}