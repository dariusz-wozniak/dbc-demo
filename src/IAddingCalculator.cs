using System;
using System.Diagnostics.Contracts;
using NUnit.Framework;

namespace DesignByContract
{
    interface IAddingCalculator
    {
        int Add(int a, int b);
        int GetLastResult();
    }

    class AddingCalculator : IAddingCalculator
    {
        private int _lastResult = 0;

        public int Add(int a, int b)
        {
            if (a < 0) throw new ArgumentOutOfRangeException();
            if (b < 0) throw new ArgumentOutOfRangeException();
            // HINT: You may use Contract.EndContractBlock();

            return _lastResult = a + b;
        }

        public int GetLastResult()
        {
            return _lastResult;
        }
    }

    class AddingCalculatorCodeContracts : IAddingCalculator
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

    [TestFixture]
    class CalculatorSandbox
    {
        [Test, Ignore]
        public void Playground()
        {
            var calculator = new AddingCalculatorCodeContracts();
            // CASE 1: Broke preconditions
            // calculator.Add(-1, 0);

            // CASE 2: Broke object invariants
            // calculator.Add(Int32.MaxValue, 1);

            // CASE 3: Remember to include Contract.EndContractBlock();
            //var oldCalculator = new AddingCalculator();
            //oldCalculator.Add(-1, 0);
        }
    }
}