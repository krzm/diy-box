using CLIHelper;
using Serilog;

namespace DiyBox.Core;

public class PrintBoxOnSheetWizard 
    : DiyBoxWizardBase
{
    private readonly IDiyBoxCompute boxCompute;

    public PrintBoxOnSheetWizard(
        IDiyBoxCompute boxCompute
        , IDictionary<Descriptors, IDescriptor> descriptor
        , IInput input
        , ILogger logger)
        : base(descriptor, input, logger)
    {
        this.boxCompute = boxCompute;
    }

    public override void Calculate(string[] args)
    {
        boxCompute.Compute(args);
    }

    public override void DefineWizardSteps()
    {
        GetText(
            Descriptors.PrintOnSheet
            , boxCompute);
    }
}