using CLIHelper;
using Serilog;

namespace DiyBox.Core;

public class BoxToSheetWizard 
    : DiyBoxWizardBase
{
    private readonly IBoxToSheetCompute boxToSheetCompute;

    public BoxToSheetWizard(
        IBoxToSheetCompute boxToSheetCompute
        , IDictionary<Descriptors, IDescriptor> descriptor
        , IInput input
        , ILogger logger)
        : base(descriptor, input, logger)
    {
        this.boxToSheetCompute = boxToSheetCompute;
    }

    public override void Calculate(string[] args)
    {
        boxToSheetCompute.Compute(args);
    }

    public override void DefineWizardSteps()
    {
        ArgumentNullException.ThrowIfNull(boxToSheetCompute.Sheet);
        GetText(
            Descriptors.PrepareSheet
            , boxToSheetCompute.Sheet);
    }
}