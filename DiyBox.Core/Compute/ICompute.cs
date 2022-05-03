namespace DiyBox.Core;

public interface ICompute<in TInput, out TOutput>
{
    TOutput Compute(TInput input);
}