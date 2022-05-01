using CLIHelper;
using Serilog;

namespace DiyBox.Core;

public class PrintOnSheetWizard 
    : DiyBoxWizardBase
{
    private readonly IBoxCalculator boxCalculator;

    public PrintOnSheetWizard(
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
        GetText(
            Descriptors.PrintOnSheet
            , boxCalculator);
    }
}