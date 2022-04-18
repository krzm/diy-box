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
        , ILogger logger)
        : base(descriptor, logger)
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