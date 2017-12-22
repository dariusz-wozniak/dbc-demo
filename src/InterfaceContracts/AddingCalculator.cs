using System.Diagnostics.Contracts;

namespace DesignByContract.InterfaceContracts
{
    public class AddingCalculator : IAddingCalculator
    {
        private int _lastResult = 0;

        public int Add(int a, int b)
        {
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