using CLIHelper;
using Serilog;

namespace DiyBox.Core;

public class DiyBoxWizard 
    : DiyBoxWizardBase
{
    private readonly IBoxCalculator boxCalculator;

    public DiyBoxWizard(
        IBoxCalculator boxCalculator
        , IDictionary<Descriptors, IDescriptor> descriptor
        , IInput input
        , ILogger logger) 
        : base(descriptor, input, logger)
    {
        this.boxCalculator = boxCalculator;
    }

    protected override void Calculate(string[] args)
    {
        boxCalculator.Calculate(args);
    }

    protected override void DefineWizardSteps()
    {
        var bc = boxCalculator;
        var sc = bc.SheetCalculator;
        ArgumentNullException.ThrowIfNull(sc);
        ArgumentNullException.ThrowIfNull(sc.BoxSize);
        ArgumentNullException.ThrowIfNull(sc.Sheet);
        GetText(
            Descriptors.BoxDimension
            , sc.BoxSize);
        GetText(Descriptors.StartCreator, new Object());
        NextStep();
        GetText(
            Descriptors.PrepareSheet
            , sc.Sheet);
        NextStep();
        GetText(
            Descriptors.MarkSheetHorizontally
            , bc);
        NextStep();
        GetText(
            Descriptors.MarkSheetVerticallyFront
            , bc);
        NextStep();
        GetText(
            Descriptors.MarkSheetVerticallySide
            , bc);
        NextStep();
        GetText(Descriptors.FoldBox, new Object());
    }
}