namespace DiyBox.Core;

public  class SheetToBoxCompute
    : ISheetToBoxCompute
{
    private const int MaxCount = 50;
    private readonly IArgsParser<Size2d> parser;
    private readonly IBoxCompute box;
    private readonly ISheetCompute sheet;
    private double errorX;
    private double errorY;
    private bool IsXCorected;
    private bool IsZCorected;
    private bool IsYCorected;
    private int loopCount;

    public Size2d? SheetSize { get; private set; }
    public IBoxCompute? Box { get; private set; }
    public ISheetCompute? Sheet { get; private set; }
    public Size3d? ResultBoxSize { get; private set; }

    public SheetToBoxCompute(
        IArgsParser<Size2d> parser
        , IBoxCompute box
        , ISheetCompute sheet
    )
    {
        this.parser = parser;
        this.box = box;
        this.sheet = sheet;
        Reset();
    }

    private void Reset()
    {
        loopCount = 0;
        IsXCorected = true;
        IsYCorected = false;
        IsZCorected = false;
    }

    private void SwitchXZCorrection()
    {
        if(IsXCorected)
        {
            IsXCorected = false;
            IsYCorected = false;
            IsZCorected = true;
            return;
        }
        if(IsZCorected)
        {
            IsXCorected = true;
            IsYCorected = false;
            IsZCorected = false;
            return;
        }
    }

    private void SwitchToYCorrection()
    {
        IsXCorected = false;
        IsYCorected = true;
        IsZCorected = false;
    }

    public ISheetToBoxCompute Compute(string[] args)
    {
        Reset();
        SheetSize = parser.Parse(args);
        var boxSize = GetFirstBoxSize();
        Compute(boxSize);
        while (IsErrorInAcceptableAccuracy() == false)
        {
            boxSize = GetCorrectedBoxSize(boxSize);
            Compute(boxSize);
            loopCount++;
            if(MaxCount < loopCount)
                throw new InvalidOperationException($"Terminating compute that cant achive result in {MaxCount} steps");
        }
        ResultBoxSize = boxSize;
        return this;
    }

    private void Compute(Size3d boxSize)
    {
        Box = box.Compute(boxSize);
        Sheet = sheet.Compute(Box);
        CalculateError();
    }

    private void CalculateError()
    {
        ArgumentNullException.ThrowIfNull(SheetSize);
        ArgumentNullException.ThrowIfNull(Sheet);
        ArgumentNullException.ThrowIfNull(Sheet.Size);
        errorX = SheetSize.X - Sheet.Size.X;
        errorY = SheetSize.Y - Sheet.Size.Y;
    }

    private Size3d GetFirstBoxSize()
    {
        ArgumentNullException.ThrowIfNull(SheetSize);
        var x = (int)(SheetSize.X/4) - 1;
        var y = (int)(SheetSize.Y/3) - 1;
        var z = x;
        return new Size3d(
            x
            , y
            , z
        );
    }

    private bool IsErrorInAcceptableAccuracy()
    {
        var x = errorX >= 0 && errorX <= 1;
        if(x && IsYCorected == false)
        {
            SwitchToYCorrection();
        }
        var y = errorY == 0;
        if(y & IsYCorected)
        {
            IsYCorected = false;
        }
        return x && y;
    }

    private Size3d GetCorrectedBoxSize(Size3d box)
    {
        var deltaX = 0.0;
        if(errorX <= -1) deltaX = -1.0;
        if(errorX > 1) deltaX = 1.0;
        var deltaY = 0.0;
        if(errorY <= -1) deltaY = -1.0;
        if(errorY >= 1) deltaY = 1.0;
        var boxX = IsXCorected ? 
            box.X + deltaX 
            : box.X;
        var boxY = IsYCorected ? 
            box.Y + deltaY 
            : box.Y;
        var boxZ = IsZCorected ? 
            box.Z + deltaX 
            : box.Z;
        if(IsXCorected || IsZCorected)
            SwitchXZCorrection();
        return new Size3d(
            boxX
            , boxY
            , boxZ);
    }
}