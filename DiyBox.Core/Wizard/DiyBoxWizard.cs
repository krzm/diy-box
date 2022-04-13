using DiyBox.Core;
using Serilog;
using System;
using System.Collections.Generic;

namespace DiyBox.Core;

public class DiyBoxWizard : IDiyBoxWizard
{
    private readonly IArgsParser<Size3d> parser;
    private readonly IDictionary<Descriptors, IDescriptor> descriptors;
    private readonly ILogger logger;

    public DiyBoxWizard(
        IArgsParser<Size3d> parser
        , IDictionary<Descriptors, IDescriptor> descriptors
        , ILogger logger)
    {
        this.parser = parser;
        this.descriptors = descriptors;
        this.logger = logger;
    }

    public void RunWizard(string[] args)
    {
        try
        {
            var objectSize = parser.Parse(args);
            var box = new Box(objectSize);
            var sheet = new Sheet(box);
            var waste = new Waste(box, sheet);
            var boxAndWaste = new BoxAndWaste(box, waste);
            GetText(
                Descriptors.ObjectDimensions
                , objectSize);
            GetText(Descriptors.StartCreator);
            NextStep();
            GetText(
                Descriptors.PrepareSheet
                , sheet);
            NextStep();
            GetText(
                Descriptors.MarkSheetHorizontally
                , box);
            NextStep();
            GetText(
                Descriptors.MarkSheetVerticallyFront
                , boxAndWaste);
            NextStep();
            GetText(
                Descriptors.MarkSheetVerticallySide
                , boxAndWaste);
            NextStep();
            GetText(Descriptors.FoldBox);
        }
        catch (ArgumentException ex)
        {
            GetText(
                Descriptors.HelpDescriptor
                , ex.Message);
        }
    }

    private void GetText(
        Descriptors descriptor
        , object data = null)
    {
        logger.Information(
            descriptors[descriptor]
                .GetDescription(data));
    }

    private void NextStep()
    {
        GetText(
            Descriptors.NextStep);
        System.Console.ReadLine();
    }
}