using CLIHelper;
using Serilog;

namespace DiyBox.Core;

public class SheetWizard 
    : DiyBoxWizardBase
{
    private readonly IBoxToSheetCompute sheetCalculator;

    public SheetWizard(
        IBoxToSheetCompute sheetCalculator
        , IDictionary<Descriptors, IDescriptor> descriptor
        , IInput input
        , ILogger logger)
        : base(descriptor, input, logger)
    {
        this.sheetCalculator = sheetCalculator;
    }

    protected override void Calculate(string[] args)
    {
        sheetCalculator.Compute(args);
    }

    protected override void DefineWizardSteps()
    {
        ArgumentNullException.ThrowIfNull(sheetCalculator.Sheet);
        GetText(
            Descriptors.PrepareSheet
            , sheetCalculator.Sheet);
    }
}