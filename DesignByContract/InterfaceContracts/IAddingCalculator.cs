using System.Diagnostics.Contracts;

namespace DesignByContract.InterfaceContracts
{
    [ContractClass(typeof(AddingCalculatorContract))]
    public interface IAddingCalculator
    {
        /// <summary>
        /// Adds two positive numbers
        /// </summary>
        /// <param name="a">First adder</param>
        /// <param name="b">Second adder</param>
        /// <returns>Returns sum of two positive numbers</returns>
        int Add(int a, int b);

        /// <summary>
        /// Gets last sum
        /// </summary>
        /// <returns></returns>
        int GetLastResult();
    }
}