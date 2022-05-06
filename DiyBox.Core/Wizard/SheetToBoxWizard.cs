using CLIHelper;
using Serilog;

namespace DiyBox.Core;

public class SheetToBoxWizard 
    : DiyBoxWizardBase
{
    private readonly ISheetToBoxCompute sheetToBoxCompute;
    private readonly IDiyBoxWizard printBoxOnSheetWizard;
    private string[]? boxArgs;

    public SheetToBoxWizard(
        ISheetToBoxCompute sheetToBoxCompute
        , IDiyBoxWizard printBoxOnSheetWizard
        , IDictionary<Descriptors, IDescriptor> descriptor
        , IInput input
        , ILogger logger)
        : base(descriptor, input, logger)
    {
        this.sheetToBoxCompute = sheetToBoxCompute;
        this.printBoxOnSheetWizard = printBoxOnSheetWizard;
    }

    public override void Calculate(string[] args)
    {
        sheetToBoxCompute.Compute(args);
        ArgumentNullException.ThrowIfNull(sheetToBoxCompute.ResultBoxSize);
        boxArgs = new string[] {
            sheetToBoxCompute.ResultBoxSize.X.ToString()
            , sheetToBoxCompute.ResultBoxSize.Y.ToString()
            , sheetToBoxCompute.ResultBoxSize.Z.ToString()
        };
        printBoxOnSheetWizard.Calculate(boxArgs);
    }

    public override void DefineWizardSteps()
    {
        ArgumentNullException.ThrowIfNull(boxArgs);
        printBoxOnSheetWizard.RunWizard(boxArgs);
    }
}