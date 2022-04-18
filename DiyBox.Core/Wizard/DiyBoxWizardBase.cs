using Serilog;
using System;
using System.Collections.Generic;

namespace DiyBox.Core;

public abstract class DiyBoxWizardBase
    : IDiyBoxWizard
{
    private readonly IDictionary<Descriptors, IDescriptor> descriptor;
    private readonly ILogger logger;

    protected DiyBoxWizardBase(
        IDictionary<Descriptors, IDescriptor> descriptor
        , ILogger logger
    )
    {
        this.descriptor = descriptor;
        this.logger = logger;
    }

    public void RunWizard(string[] args)
    {
        try
        {
            Calculate(args);
            DefineWizardSteps();
        }
        catch (ArgumentException ex)
        {
            HandleError(ex);
        }
    }
    
    protected abstract void Calculate(string[] args);

    protected abstract void DefineWizardSteps();

    protected virtual void HandleError(
        ArgumentException ex)
    {
        GetText(
            Descriptors.HelpDescriptor
            , ex.Message);
    }

    protected void GetText(
        Descriptors descriptorKey
        , object data = null)
    {
        logger.Information(
            descriptor[descriptorKey]
                .GetDescription(data));
    }

    protected void NextStep()
    {
        GetText(
            Descriptors.NextStep);
        System.Console.ReadLine();
    }
}