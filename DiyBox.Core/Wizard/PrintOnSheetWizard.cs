using CLIHelper;
using Serilog;

namespace DiyBox.Core;

public class PrintOnSheetWizard 
    : DiyBoxWizardBase
{
    private readonly IDiyBoxCompute boxCalculator;

    public PrintOnSheetWizard(
        IDiyBoxCompute boxCalculator
        , IDictionary<Descriptors, IDescriptor> descriptor
        , IInput input
        , ILogger logger)
        : base(descriptor, input, logger)
    {
        this.boxCalculator = boxCalculator;
    }

    protected override void Calculate(string[] args)
    {
        boxCalculator.Compute(args);
    }

    protected override void DefineWizardSteps()
    {
        GetText(
            Descriptors.PrintOnSheet
            , boxCalculator);
    }
}