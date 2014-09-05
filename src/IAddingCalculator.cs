using System;
using System.Diagnostics.Contracts;

namespace DesignByContract
{
    interface IAddingCalculator
    {
        int Add(int a, int b);
        int GetLastResult();
    }

    class AddingCalculator : IAddingCalculator
    {
        private int lastResult = 0;

        public int Add(int a, int b)
        {
            if (a < 0) throw new ArgumentOutOfRangeException();
            if (b < 0) throw new ArgumentOutOfRangeException();
            // HINT: You may use Contract.EndContractBlock();

            return lastResult = a + b;
        }

        public int GetLastResult()
        {
            return lastResult;
        }
    }

    class AddingCalculator_CodeContracts : IAddingCalculator
    {
        private int lastResult = 0;

        public int Add(int a, int b)
        {
            Contract.Requires<ArgumentOutOfRangeException>(a >= 0);
            Contract.Requires<ArgumentOutOfRangeException>(b >= 0);
            Contract.Ensures(Contract.Result<int>() >= 0);

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
}