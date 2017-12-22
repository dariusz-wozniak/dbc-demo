using System;
using System.Diagnostics.Contracts;

namespace DesignByContract
{
    public interface IAddingCalculator
    {
        int Add(int a, int b);
        int GetLastResult();
    }

    public class AddingCalculatorCodeContracts : IAddingCalculator
    {
        private int _lastResult = 0;

        public int Add(int a, int b)
        {
            Contract.Requires<ArgumentOutOfRangeException>(a >= 0);
            Contract.Requires<ArgumentOutOfRangeException>(b >= 0);
            Contract.Ensures(Contract.Result<int>() >= 0);

            return _lastResult = a + b;
        }

        public int GetLastResult()
        {
            return _lastResult;
        }

        [ContractInvariantMethod]
        private void CheckIfLastResultIsInRange()
        {
            Contract.Invariant(_lastResult >= 0);
        }
    }
}