﻿using Serilog;
using System.Collections.Generic;

namespace DiyBox.Core;

public class DiyBoxWizard 
    : DiyBoxWizardBase
{
    private readonly IBoxCalculator boxCalculator;

    public DiyBoxWizard(
        IBoxCalculator boxCalculator
        , IDictionary<Descriptors, IDescriptor> descriptor
        , ILogger logger) 
        : base(descriptor, logger)
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
        GetText(
            Descriptors.BoxDimension
            , sc.BoxSize);
        GetText(Descriptors.StartCreator);
        NextStep();
        GetText(
            Descriptors.PrepareSheet
            , sc.Sheet);
        NextStep();
        GetText(
            Descriptors.MarkSheetHorizontally
            , sc.Box);
        NextStep();
        GetText(
            Descriptors.MarkSheetVerticallyFront
            , bc);
        NextStep();
        GetText(
            Descriptors.MarkSheetVerticallySide
            , bc);
        NextStep();
        GetText(Descriptors.FoldBox);
    }
}