using System;
using System.Diagnostics.Contracts;

namespace DesignByContract.InterfaceContracts
{
    [ContractClass(typeof(IAddingCalculatorContract))]
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

    [ContractClassFor(typeof(IAddingCalculator))]
    abstract class IAddingCalculatorContract : IAddingCalculator
    {
        public int Add(int a, int b)
        {
            Contract.Requires<ArgumentOutOfRangeException>(a >= 0);
            Contract.Requires<ArgumentOutOfRangeException>(b >= 0);
            Contract.Ensures(Contract.Result<int>() >= 0);
            return default(int);
        }

        public int GetLastResult()
        {
            Contract.Ensures(Contract.Result<int>() >= 0);
            return default(int);
        }
    }

    class AddingCalculator : IAddingCalculator
    {
        private int lastResult = 0;

        public int Add(int a, int b)
        {
            return lastResult = a + b;
        }

        public int GetLastResult()
        {
            return lastResult;
        }

        [ContractInvariantMethod]
        private void CheckIfLastResultIsInRange()
        {
            Contract.Invariant(lastResult >= 0);
        }
    }

    class CalculatorController
    {
        public void Add(IAddingCalculator calc)
        {
            Contract.Requires<ArgumentNullException>(calc != null);

            calc.Add(0, 0);
        }
    }
}