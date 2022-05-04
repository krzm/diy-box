namespace DiyBox.Core;

public  class SheetToBoxCompute
    : ISheetToBoxCompute
{
    private readonly IArgsParser<Size2d> parser;
    private readonly IBoxCompute box;
    private readonly ISheetCompute sheet;

    public Size2d? SheetSize { get; private set; }
    public IBoxCompute? Box { get; private set; }
    public ISheetCompute? Sheet { get; private set; }

    public SheetToBoxCompute(
        IArgsParser<Size2d> parser
        , IBoxCompute box
        , ISheetCompute sheet
    )
    {
        this.parser = parser;
        this.box = box;
        this.sheet = sheet;
    }

    public ISheetToBoxCompute Compute(string[] args)
    {
        SheetSize = parser.Parse(args);
        Compute(GetFirstBoxSize());
        while (IsErrorInAcceptableAccuracy())
        {
            Compute(GetCorrectedBoxSize());
        }
        return this;
    }

    private Size3d GetCorrectedBoxSize()
    {
        throw new NotImplementedException();
    }

    private void Compute(Size3d boxSize)
    {
        Box = box.Compute(boxSize);
        Sheet = sheet.Compute(Box);
        CalculateError();
    }

    private bool IsErrorInAcceptableAccuracy()
    {
        throw new NotImplementedException();
    }

    private object CalculateError()
    {
        throw new NotImplementedException();
    }

    private Size3d GetFirstBoxSize()
    {
        throw new NotImplementedException();
    }
}