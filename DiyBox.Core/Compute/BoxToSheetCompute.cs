namespace DiyBox.Core;

public class BoxToSheetCompute 
    : IBoxToSheetCompute
{
    private readonly IArgsParser<Size3d> parser;
    private readonly IBoxCompute box;
    private readonly ISheetCompute sheet;

    public Size3d? BoxSize { get; private set; }
    public IBoxCompute? Box { get; private set; }
    public ISheetCompute? Sheet { get; private set; }

    public BoxToSheetCompute(
        IArgsParser<Size3d> parser
        , IBoxCompute box
        , ISheetCompute sheet
    )
    {
        this.parser = parser;
        this.box = box;
        this.sheet = sheet;
    }

    public IBoxToSheetCompute Compute(string[] args)
    {
        BoxSize = parser.Parse(args);
        Box = box.Compute(BoxSize);
        Sheet = sheet.Compute(Box);
        return this;
    }
}