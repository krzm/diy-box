namespace DiyBox.Core;

public interface IDiyBoxWizard
{
    void RunWizard(string[] args);

    void Calculate(string[] args);

    void DefineWizardSteps();
}