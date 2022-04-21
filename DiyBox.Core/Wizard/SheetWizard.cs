using CLIHelper;
using Serilog;
using System.Collections.Generic;

namespace DiyBox.Core;

public class SheetWizard 
    : DiyBoxWizardBase
{
    private readonly ISheetCalculator sheetCalculator;

    public SheetWizard(
        ISheetCalculator sheetCalculator
        , IDictionary<Descriptors, IDescriptor> descriptor
        , IInput input
        , ILogger logger)
        : base(descriptor, input, logger)
    {
        this.sheetCalculator = sheetCalculator;
    }

    protected override void Calculate(string[] args)
    {
        sheetCalculator.Calculate(args);
    }

    protected override void DefineWizardSteps()
    {
        GetText(
            Descriptors.PrepareSheet
            , sheetCalculator.Sheet);
    }
}