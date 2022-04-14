using Serilog;
using System;
using System.Collections.Generic;

namespace DiyBox.Core;

public class SheetWizard 
    : IDiyBoxWizard
{
    private readonly IArgsParser<Size3d> parser;
    private readonly IDictionary<Descriptors, IDescriptor> descriptors;
    private readonly ILogger logger;

    public SheetWizard(
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
            GetText(
                Descriptors.PrepareSheet
                , sheet);
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